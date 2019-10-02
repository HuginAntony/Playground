using System.IO;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace RabbitMQDemo
{
    public class RabbitMqFactory
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;
        private static RabbitMqSettings _rabbitMqSettings;

        public RabbitMqFactory()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

           var configuration = builder.Build();

           _rabbitMqSettings = configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
            CreateConnection();
        }

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = _rabbitMqSettings.Host,
                UserName = _rabbitMqSettings.Username,
                Password = _rabbitMqSettings.Password
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_rabbitMqSettings.ExchangeName, _rabbitMqSettings.ExchangeType);

            foreach (var queue in _rabbitMqSettings.Queues)
            {
                _channel.QueueDeclare(queue, true, false, false, null);
                _channel.QueueBind(queue, _rabbitMqSettings.ExchangeName, queue);
            }
        }

        public void SendMessage<T>(T message, string routingKey)
        {
            byte[] messageBytes = message.Serialize();

            IBasicProperties props = _channel.CreateBasicProperties();
            props.ContentType = "application/json";
            props.DeliveryMode = 2;

            _channel.BasicPublish(_rabbitMqSettings.ExchangeName, routingKey, props, messageBytes);
        }
        public void Close()
        {
            _connection.Close();
        }
    }
}