using System.Text;
using System.Text.Json;
using app.FacturaSubscribe.Entities.Models;
using app.FacturaSubscribe.services.Config;
using app.FacturaSubscribe.services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace app.FacturaSubscribe.services.MQ
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RabbitMqConsumerService> _logger;
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMqConsumerService(ILogger<RabbitMqConsumerService> logger,
              IOptions<RabbitMQSettings> rabbitMQSettings, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _rabbitMQSettings = rabbitMQSettings.Value;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _rabbitMQSettings.Hostname!,
                    Port = _rabbitMQSettings.Port!,
                    UserName = _rabbitMQSettings.Username!,
                    Password = _rabbitMQSettings.Password!,
                    VirtualHost = _rabbitMQSettings.VirtualHost!
                };

                var connection = await factory.CreateConnectionAsync();
                var channel = await connection.CreateChannelAsync();

                var queueNames = new[]
                {
                    "categoriasQueue",
                    "clientesQueue",
                    "productosQueue",
                    "ventasQueue",
                    "facturaDtoQueue",
                    "usuariosQueue"
                };

                foreach (var queueName in queueNames)
                {
                    var qName = queueName;

                    await channel.QueueDeclareAsync(
                        queue: qName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false
                    );

                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.ReceivedAsync += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        using var scope = _serviceProvider.CreateScope();
                        var servicio = scope.ServiceProvider.GetRequiredService<IProcesoService>();

                        switch (qName)
                        {
                            case "categoriasQueue":
                                var categoria = JsonSerializer.Deserialize<Categoria>(message);
                                _logger.LogInformation("Categoría recibida: {Nombre}", categoria?.Nombre);
                                await servicio.GuardarCategoriaAsync(categoria!);
                                break;

                            case "clientesQueue":
                                var cliente = JsonSerializer.Deserialize<Cliente>(message);
                                _logger.LogInformation("Cliente recibido: {Nombre}", cliente?.Nombre);
                                await servicio.GuardarClienteAsync(cliente!);
                                break;

                            case "productosQueue":
                                var producto = JsonSerializer.Deserialize<Producto>(message);
                                _logger.LogInformation("Producto recibido: {Nombre}", producto?.Nombre);
                                await servicio.GuardarProductoAsync(producto!);
                                break;

                            case "ventasQueue":
                                var venta = JsonSerializer.Deserialize<Venta>(message);
                                _logger.LogInformation("Venta recibida: {Id}", venta?.Id);
                                await servicio.GuardarVentaAsync(venta!);
                                break;

                            case "facturaDtoQueue":
                                var detalle = JsonSerializer.Deserialize<VentaDetalle>(message);
                                _logger.LogInformation("Detalle recibido: {Id}", detalle?.Id);
                                await servicio.GuardarVentaDetalleAsync(detalle!);
                                break;

                            case "usuariosQueue":
                                var usuario = JsonSerializer.Deserialize<Usuario>(message);
                                _logger.LogInformation("Usuario recibido: {Nombre}", usuario?.Correo);
                                await servicio.GuardarUsuarioAsync(usuario!);
                                break;
                        }
                    };

                    await channel.BasicConsumeAsync(
                        queue: qName,
                        autoAck: true,
                        consumer: consumer
                    );
                }
            }
            catch (BrokerUnreachableException ex)
            {
                _logger.LogError($"Error conectando con RabbitMQ: {ex.Message}");
            }
        }
    }
}

