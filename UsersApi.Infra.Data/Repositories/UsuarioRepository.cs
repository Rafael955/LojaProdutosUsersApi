using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Enums;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Execute(Usuario usuario, TipoOperacao operation)
        {
            using (var dataContext = new DataContext())
            {
                switch (operation)
                {
                    case TipoOperacao.Inserir:
                        dataContext.Add(usuario);
                        break;
                    case TipoOperacao.Alterar:
                        dataContext.Update(usuario);
                        break;
                    case TipoOperacao.Excluir:
                        dataContext.Remove(usuario);
                        break;
                }

                dataContext.SaveChanges();
            }
        }

        public List<Usuario> GetAll()
        {
            using var dataContext = new DataContext();

            return dataContext.Set<Usuario>().ToList();
        }

        public Usuario GetById(Guid id)
        {
            using var dataContext = new DataContext();

            return dataContext.Set<Usuario>().Find(id);
        }

        public Usuario? GetByEmailAndPassword(string email, string password)
        {
            using var dataContext = new DataContext();

            return dataContext.Set<Usuario>()
                .Include(x => x.Perfil)
                .FirstOrDefault(x => x.Email == email && x.Senha == password);
        }

        public bool HasEmail(string email)
        {
            using var dataContext = new DataContext();

            return dataContext.Set<Usuario>()
                .Any(x => x.Email.Equals(email));
        }
    }
}
