using System;
using System.Text;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UsersAPI.Infra.Message.Helpers;
using UsersAPI.Infra.Message.Models;
using UsersAPI.Infra.Message.Settings;

namespace UsersAPI.Infra.Message.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly RabbitMQSettings _rabbitMQSettings = new RabbitMQSettings();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //configurando a conexão com o servidor de mensageria
            var connectionFactory = new ConnectionFactory
            {
                HostName = _rabbitMQSettings.Host,
                Port = _rabbitMQSettings.Port,
                UserName = _rabbitMQSettings.User,
                Password = _rabbitMQSettings.Password,
                VirtualHost = _rabbitMQSettings.VirtualHost
            };

            //abrindo a conexão com o servidor da mensageria
            var connection = connectionFactory.CreateConnection();

            //acessando a fila
            var model = connection.CreateModel();
            model.QueueDeclare(
                queue: _rabbitMQSettings.Queue, //nome da fila
                durable: true, //fila não será excluida automaticamente
                exclusive: false, // fila compartilhada
                autoDelete: false, //fila não exclui registros automaticamente
                arguments: null
            );

            //configurando uma rotina para ler cada registro contido na mensageria
            var consumer = new EventingBasicConsumer(model);

            //RECEIVED: Ler cada registro obtido da fila
            consumer.Received += (sender, args) =>
            {
                //ler o campo Payload do RabbitMQ
                var payload = args.Body.ToArray(); //formato bytes

                //converter para string (json)
                var json = Encoding.UTF8.GetString(payload);

                //deserializando os dados de JSON para objeto
                var usuarioRegistrado = JsonConvert.DeserializeObject<UsuarioRegistrado>(json);

                //enviando o email para o usuário
                var mailHelper = new MailHelper();
                mailHelper.SendMail(usuarioRegistrado);

                //retirar o registro da fila
                model.BasicAck(args.DeliveryTag, false);
            };

            //executando e finalizando a leitura...
            model.BasicConsume(
                queue: _rabbitMQSettings.Queue,
                consumer: consumer,
                autoAck: false
            );
        }
    }
}