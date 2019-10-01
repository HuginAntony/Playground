using RabbitMQ.Client;

namespace RabbitMQDemo
{
    public class RabbitMqFactory
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;

        private const string ExchangeName = "Entertainment";
        private const string Movies = "Movies";
        private const string Music = "Music";
        private const string Games = "Games";

        public RabbitMqFactory()
        {
            CreateConnection();
        }

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, "topic");

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