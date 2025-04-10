using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using app.projectDelgadoAedra.common.EventMQ;
using Microsoft.Extensions.Options;

namespace app.projectDelgadoAedra_services.EventMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQSettings _settings;

        public RabbitMQService(IOptions<RabbitMQSettings> options)
        {
            _settings = options.Value;
        }

        public async Task PublishMessage<T>(T message, string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _settings.Hostname!,
                Port = _settings.Port,
                UserName = _settings.Username!,
                Password = _settings.Password!,
                VirtualHost = _settings.VirtualHost!,
            };


            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queueName,
                                       durable: true,
                                       exclusive: false,
                                       autoDelete: false,
                                       arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body);

        }
    }
}
