using RabbitMQ.Client;
using Services.Interfaces;
using System;
using System.Text;

namespace Services
{


    public class ProducerService : IProducerService
    {
        //Most of the stuff in here would be driven by app configurations. Tad uneccesary in this case
        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
        public void SendMessage(string message)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "MessageQueue",
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                            routingKey: "messageKey",
                            basicProperties: null,
                            body: body);
                    Console.WriteLine(" [x] Sent {0}", message);

                }
            }
        }
    }
}
