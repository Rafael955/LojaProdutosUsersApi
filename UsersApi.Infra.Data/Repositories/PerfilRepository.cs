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
    public class PerfilRepository : IPerfilRepository
    {
        public void Execute(Perfil perfil, TipoOperacao operation)
        {
            using (var dataContext = new DataContext())
            {
                switch (operation)
                {
                    case TipoOperacao.Inserir:
                        dataContext.Add(perfil);
                        break;
                    case TipoOperacao.Alterar:
                        dataContext.Update(perfil);
                        break;
                    case TipoOperacao.Excluir:
                        dataContext.Remove(perfil);
                        break;
                }
                dataContext.SaveChanges();
            }
        }
        public List<Perfil> GetAll()
        {
            using var dataContext = new DataContext();
            return dataContext.Set<Perfil>().ToList();
        }
        public Perfil GetById(Guid id)
        {
            using var dataContext = new DataContext();
            return dataContext.Set<Perfil>().Find(id);
        }
        public Perfil? GetByName(string nome)
        {
            using var dataContext = new DataContext();
            return dataContext.Set<Perfil>()
                .FirstOrDefault(x => x.Nome == nome);
        }
    }
}
