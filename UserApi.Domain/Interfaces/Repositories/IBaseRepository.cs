using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Enums;

namespace UsersApi.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Execute(T entity, TipoOperacao operation);

        T GetById(Guid id);

        List<T> GetAll();
    }
}
