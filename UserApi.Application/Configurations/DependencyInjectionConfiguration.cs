using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Repositories;

namespace UserApi.Application.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            service.AddTransient<IUsuarioRepository, UsuarioRepository>();
            service.AddTransient<IPerfilRepository, PerfilRepository>();
        }
    }
}
