using HelpdeskBot.Services.contracts;
using RabbitMQ.Client;
using System.Text;

namespace HelpdeskBot.Services
{
    public class RabbitService : IRabbitService
    {
        private readonly ConnectionFactory _factory;

        public RabbitService(ConnectionFactory factory)
        {
            _factory = factory;
        }

        public void EnviarMensagem(string mensagem)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            //var arguments = new Dictionary<string, object>
            //{
            //    { "x-message-ttl", 60000 }  
            //};

            //channel.QueueDeclare( queue: "dead_letter_queue",
            //    durable: true,
            //    exclusive: false,
            //    autoDelete: true,
            //    arguments: arguments);

            //var args = new Dictionary<string, object>
            //{
            //    { "x-dead-letter-exchange", "" },
            //    { "x-dead-letter-routing-key", "dead_letter_queue" }
            //};

            //channel.QueueDeclare(queue: "images_queue",
            //         durable: true,
            //         exclusive: false,
            //         autoDelete: true,
            //         arguments: args);

            var body = Encoding.UTF8.GetBytes(mensagem);


            channel.BasicPublish(exchange: "",
                                 routingKey: "images_queue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
