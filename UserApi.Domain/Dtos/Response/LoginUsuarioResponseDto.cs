using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Dtos.Response
{
    public class LoginUsuarioResponseDto
    {
        public Guid? Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Perfil { get; set; }

        public string? Token { get; set; }

        public DateTime? AcessoEm { get; set; }

        public DateTime? Expiracao { get; set; }
    }
}
