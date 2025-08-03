# Users API (.NET 9)

API para gerenciamento de usu�rios, autentica��o e envio de notifica��es, desenvolvida em .NET 9. O projeto utiliza arquitetura em camadas, Entity Framework Core, autentica��o JWT, mensageria com RabbitMQ e envio de e-mails.

## Funcionalidades

- Cadastro de usu�rios com valida��o de dados.
- Autentica��o de usu�rios via JWT.
- Associa��o de usu�rios a perfis.
- Envio de e-mail autom�tico ao cadastrar usu�rio.
- Integra��o com RabbitMQ para processamento ass�ncrono de notifica��es.
- API documentada com OpenAPI/Swagger.
- Suporte a CORS para integra��o com frontends Angular e Blazor.

## Estrutura do Projeto

- **UserApi.Application**: Camada de aplica��o e controllers.
- **UsersApi.Domain**: Entidades, DTOs, enums e interfaces de reposit�rios.
- **UsersApi.Infra.Data**: Contexto do EF Core, mapeamentos e reposit�rios.
- **UsersAPI.Infra.Message**: Integra��o com RabbitMQ e envio de e-mails.
- **UsersApi.Tests**: Testes unit�rios.

## Principais Endpoints

- `POST /api/usuarios/criar-usuario`: Cria um novo usu�rio.
- `POST /api/usuarios/login-usuario`: Realiza login e retorna token JWT.

## Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core (SQL Server)
- RabbitMQ
- JWT Bearer Authentication
- OpenAPI/Swagger
- CORS

## Configura��o e Execu��o

1. **Banco de Dados**: Configure a string de conex�o em `DataContext.cs` para seu SQL Server.
2. **RabbitMQ**: Certifique-se de que o servi�o RabbitMQ est� rodando e configurado conforme `RabbitMQSettings`.
3. **E-mail**: O envio de e-mails utiliza SMTP local (MailDev, MailHog, etc.) para testes.
4. **Build e Run**: dotnet build dotnet run --project UserApi.Application
5. **Swagger**: Acesse `/swagger` para explorar e testar a API.

## Testes

Execute os testes unit�rios com: dotnet test

## Observa��es

- O projeto j� inclui um usu�rio administrador padr�o.
- O CORS est� configurado para aceitar requisi��es de aplica��es Angular e Blazor em localhost.
- O envio de e-mails � feito de forma ass�ncrona via RabbitMQ.

---

> Projeto desenvolvido para fins de estudo e demonstra��o de arquitetura moderna com .NET.



