using System.IO;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace RabbitMQDemo
{
    public abstract class RabbitMqSettings
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
    }
    public class RabbitMqFactory
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;
        private static IConfigurationRoot _configuration;
        private static RabbitMqSettings _rabbitMqSettings;

        private const string ExchangeName = "Entertainment";
        private const string Movies = "Movies";
        private const string Music = "Music";
        private const string Games = "Games";

        public RabbitMqFactory()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

           _configuration = builder.Build();

           _rabbitMqSettings = _configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
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
            _channel.ExchangeDeclare(ExchangeName, _configuration["RabbitMqExchangeType"]);

            _channel.QueueDeclare(Movies, true, false, false, null);
            _channel.QueueDeclare(Music, true, false, false, null);
            _channel.QueueDeclare(Games, true, false, false, null);

            _channel.QueueBind(Movies, ExchangeName, Movies);
            _channel.QueueBind(Music, ExchangeName, Music);
            _channel.QueueBind(Games, ExchangeName, Games);
        }

        public void SendMessage<T>(T message, string routingKey)
        {
            byte[] messageBytes = message.Serialize();

            IBasicProperties props = _channel.CreateBasicProperties();
            props.ContentType = "application/json";
            props.DeliveryMode = 2;

            _channel.BasicPublish(ExchangeName, routingKey, props, messageBytes);
        }
        public void Close()
        {
            _connection.Close();
        }
    }
}