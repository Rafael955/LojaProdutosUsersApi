using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Entities
{
    public class Perfil
    {
        public Guid? Id { get; set; }

        public string? Nome { get; set; }

        #region Navegabilidades

        public virtual List<Usuario>? Usuarios { get; set; }

        #endregion
    }
}
