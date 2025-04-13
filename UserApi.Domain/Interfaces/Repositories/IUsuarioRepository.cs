using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Entities;

namespace UsersApi.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario? GetByEmailAndPassword(string email, string password);
        bool HasEmail(string email);
    }
}
