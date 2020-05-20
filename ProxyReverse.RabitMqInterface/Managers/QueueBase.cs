using ProxyReverse.RabitMqInterface.Entities;
using RabbitMQ.Client;

namespace ProxyReverse.RabitMqInterface.Managers
{
    internal class QueueBase
    {
        public IQueueConfigs QueueConfigs { get; }

        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        protected ConnectionFactory ConnectionFactory => _connectionFactory ?? (_connectionFactory = GetConnectionFactory());
        protected IConnection Connection => _connection ?? (_connection = ConnectionFactory.CreateConnection());
        protected IModel Channel => _channel ?? (_channel = Connection.CreateModel());
        public QueueBase(IQueueConfigs queueConfigs)
            => QueueConfigs = queueConfigs;

        public void DeclareQueue(string queueName)
            =>
            Channel.QueueDeclare(queue: queueName,
                                                durable: false,
                                                exclusive: false,
                                                autoDelete: false,
                                                arguments: null);

        protected ConnectionFactory GetConnectionFactory()
            => new ConnectionFactory()
            {
                HostName = QueueConfigs.HostName,
                UserName = QueueConfigs.UserName,
                Password = QueueConfigs.Password
            };

        public void Dispose()
        {
            _channel?.Dispose();
            _connection.Dispose();
        }

    }
}
