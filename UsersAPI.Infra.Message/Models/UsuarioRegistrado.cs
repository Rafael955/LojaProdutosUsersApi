using System;

namespace UsersAPI.Infra.Message.Models
{
    public class UsuarioRegistrado
    {
        public Guid? Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string? Perfil { get; set; }
    }
}
