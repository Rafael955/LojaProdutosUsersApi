using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Enums;

namespace UsersApi.Domain.Entities
{
    public class Usuario
    {
        public Guid? Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public Status Status { get; set; }

        public Guid? PerfilId { get; set; }

        #region Navegabilidade

        public virtual Perfil? Perfil { get; set; }

        #endregion
    }
}
