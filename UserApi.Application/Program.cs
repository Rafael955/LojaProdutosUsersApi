using UserApi.Application.Configurations;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Repositories;
using UsersAPI.Infra.Message.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registrando a classe WORKER / CONSUMER
builder.Services.AddHostedService<MessageConsumer>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPerfilRepository, PerfilRepository>();   

builder.Services.AddCorsConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCorsConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program {}
