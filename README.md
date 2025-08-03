# Users API (.NET 9)

API para gerenciamento de usuários, autenticação e envio de notificações, desenvolvida em .NET 9. O projeto utiliza arquitetura em camadas, Entity Framework Core, autenticação JWT, mensageria com RabbitMQ e envio de e-mails.

## Funcionalidades

- Cadastro de usuários com validação de dados.
- Autenticação de usuários via JWT.
- Associação de usuários a perfis.
- Envio de e-mail automático ao cadastrar usuário.
- Integração com RabbitMQ para processamento assíncrono de notificações.
- API documentada com OpenAPI/Swagger.
- Suporte a CORS para integração com frontends Angular e Blazor.

## Estrutura do Projeto

- **UserApi.Application**: Camada de aplicação e controllers.
- **UsersApi.Domain**: Entidades, DTOs, enums e interfaces de repositórios.
- **UsersApi.Infra.Data**: Contexto do EF Core, mapeamentos e repositórios.
- **UsersAPI.Infra.Message**: Integração com RabbitMQ e envio de e-mails.
- **UsersApi.Tests**: Testes unitários.

## Principais Endpoints

- `POST /api/usuarios/criar-usuario`: Cria um novo usuário.
- `POST /api/usuarios/login-usuario`: Realiza login e retorna token JWT.

## Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core (SQL Server)
- RabbitMQ
- JWT Bearer Authentication
- OpenAPI/Swagger
- CORS

## Configuração e Execução

1. **Banco de Dados**: Configure a string de conexão em `DataContext.cs` para seu SQL Server.
2. **RabbitMQ**: Certifique-se de que o serviço RabbitMQ está rodando e configurado conforme `RabbitMQSettings`.
3. **E-mail**: O envio de e-mails utiliza SMTP local (MailDev, MailHog, etc.) para testes.
4. **Build e Run**: dotnet build dotnet run --project UserApi.Application
5. **Swagger**: Acesse `/swagger` para explorar e testar a API.

## Testes

Execute os testes unitários com: dotnet test

## Observações

- O projeto já inclui um usuário administrador padrão.
- O CORS está configurado para aceitar requisições de aplicações Angular e Blazor em localhost.
- O envio de e-mails é feito de forma assíncrona via RabbitMQ.

---

> Projeto desenvolvido para fins de estudo e demonstração de arquitetura moderna com .NET.



