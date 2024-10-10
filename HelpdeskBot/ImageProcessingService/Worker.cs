using ImageProcessingService.Context;
using ChamadoDataAccessLibrary.Models;
using ImageProcessingService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ImageProcessingService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IManageChamadoService _manageChamadoService;
        private readonly IServiceScopeFactory _scopeFactory;




        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IManageChamadoService manageChamadoService, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _manageChamadoService = manageChamadoService;


            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            ConfigureRabbitMq();
            _scopeFactory = scopeFactory;
        }

        private void ConfigureRabbitMq()
        {

            _channel.QueueDeclare(queue: "dead_letter_queue",
                durable: true,
                exclusive: false,
                autoDelete: true,
                arguments: null);

            var args = new Dictionary<string, object>
            {
                { "x-dead-letter-exchange", "" },
                { "x-dead-letter-routing-key", "dead_letter_queue" }
            };

            _channel.QueueDeclare(queue: "images_queue",
                 durable: true,
                 exclusive: false,
                 autoDelete: true,
                 arguments: args);



        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Received message: {message}");

                    try
                    {
                        await ProcessMessageImagesAsync(message);
                        _channel.BasicAck(ea.DeliveryTag, false);

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error processing message: {ex.Message}");
                    }
                };

                _channel.BasicConsume(queue: "images_queue",
                         autoAck: false,
                         consumer: consumer);

                return Task.CompletedTask;
            }

        }

        private async Task ProcessMessageImagesAsync(string message)
        {
            try
            {
                await _manageChamadoService.ProcessMessage(message);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
    

