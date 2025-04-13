using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersApi.Domain.Entities;

namespace UserApi.Application.Security
{
    public class JwtBearerSecurity
    {
        public static DateTime? GetExpiration() 
        {
            return DateTime.UtcNow.AddMinutes(30);
        }

        public static string? GetAccessToken(Usuario usuario) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //gravar a chave secreta que será utilizada para assinar os tokens
            var key = Encoding.ASCII.GetBytes("CE6AAEF5-CFC1-4446-951A-BA14EB7BBD8D");

            //construindo o token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravando no corpo do TOKEN o ID do usuário autenticado
                Subject = new ClaimsIdentity(new Claim[]
                    { 
                        new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email),
                        new Claim(ClaimTypes.Role, usuario.Perfil.Nome),
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()!),
                    }),

                //gravando a data e hora de expiração do token
                Expires = GetExpiration(),

                //gravando a assinatura do token feita com a chave secreta
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //criando e retornando o token JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
