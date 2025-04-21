using System;

namespace UsersAPI.Infra.Message.Settings;

public class RabbitMQSettings
{
    public string Host = "localhost";
    public int Port = 5673;
    public string User ="guest";
    public string Password = "guest";
    public string Queue ="usuarios_registrados";
    public string VirtualHost = "/";
}
