using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Entities;

namespace UsersApi.Domain.Interfaces.Repositories
{
    public interface IPerfilRepository : IBaseRepository<Perfil>
    {
        Perfil? GetByName(string nome);
    }
}
