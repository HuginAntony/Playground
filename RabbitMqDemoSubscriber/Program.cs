using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQDemo;

namespace RabbitMqDemoSubscriber
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;

        private const string ExchangeName = "Entertainment";
        private const string GamesQueue = "Games";

        static void Main(string[] args)
        {
            CreateConnection();
            ProcessMessages();
            Console.ReadLine();
        }

        public static void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        private static void ProcessMessages()
        {
            _channel.ExchangeDeclare(ExchangeName, "topic");
            _channel.QueueDeclare(GamesQueue, true, false, false, null);

            _channel.QueueBind(GamesQueue, ExchangeName, GamesQueue);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var message = ea.Body.DeSerialize<Movie>();

                var routingKey = ea.RoutingKey;

                Console.WriteLine("Retrieved Movie - Routing Key <{0}> : {1} : {2}", routingKey, message.Name, message.Year);

                        // ... process the message
                        _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(GamesQueue, false, consumer);

            Console.WriteLine("\r\n\r\nWaiting for messages...");
        }
        public void Close()
        {
            _connection.Close();
        }
    }
}
