using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Application.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection service)
    {
        //Configuração do CORS (permissão para o Angular acessar os endpoints da API)
        service.AddCors(options =>
        {
            options.AddPolicy(name: "AllowFrontEndApps", policy =>
            {
                policy.WithOrigins("http://localhost:4200", "http://localhost:5051") // URL da aplicação Angular e aplicação Blazor
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }

    public static void UseCorsConfiguration(this IApplicationBuilder app)
    {
        app.UseCors("AllowFrontEndApps");
    }
    }
}