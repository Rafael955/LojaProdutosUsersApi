using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Application.Security;
using UsersApi.Domain.Dtos.Request;
using UsersApi.Domain.Dtos.Response;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Enums;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Helpers;
using UsersAPI.Infra.Message.Models;
using UsersAPI.Infra.Message.Producers;

namespace UserApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
        }

        [HttpPost("criar-usuario")]
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] CriarUsuarioRequestDto request)
        {
            try
            {
                if (_usuarioRepository.HasEmail(request.Email))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        message = "Já existe um usuário cadastrado com esse email. Informe outro."
                    });
                }

                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = SHA256Encrypt.Encrypt(request.Senha),
                    Status = Status.Ativo,
                    PerfilId = _perfilRepository.GetByName("OPERADOR")?.Id
                };

                _usuarioRepository.Execute(usuario, TipoOperacao.Inserir);

                var messageProducer = new MessageProducer();
                messageProducer.SendMessage(new UsuarioRegistrado
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    CriadoEm = DateTime.Now,
                    Perfil = "OPERADOR"
                });

                return StatusCode(StatusCodes.Status201Created, new CriarUsuarioResponseDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    CriadoEm = DateTime.Now,
                    Perfil = "OPERADOR"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("login-usuario")]
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] LoginUsuarioRequestDto request)
        {
            try
            {
                var usuario = _usuarioRepository.GetByEmailAndPassword(request.Email, SHA256Encrypt.Encrypt(request.Senha));

                if (usuario == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        message = "Acesso negado. Usuário não encontrado."
                    });
                }

                var response = new LoginUsuarioResponseDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Perfil = usuario.Perfil.Nome,
                    AcessoEm = DateTime.Now,
                    Token = JwtBearerSecurity.GetAccessToken(usuario),
                    Expiracao = JwtBearerSecurity.GetExpiration()
                };

                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

    }
}
