using RabbitMQ.Client;

namespace Militaria.RabbitMQ
{
    public class RabbitClientBase :IDisposable
    {
        internal readonly string _queueName;
        internal readonly IConnection _connection;
        internal readonly IModel _channel;
        internal bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="hostName"></param>
        /// <exception cref="RabbitMQ.Client.Exception.BrokerUnrechableException"></exception>
        public RabbitClientBase(string queueName, string hostName)
        {
            _queueName = queueName;
            var factory = new ConnectionFactory()
            {
                HostName = hostName,
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            Queuedeclare();

        }
        private void Queuedeclare()
        {
            _channel.QueueDeclare(
                   queue: _queueName,
                   durable: true,
                   exclusive: false,
                   autoDelete: false,
                   arguments: null);

        }
        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    _channel?.Dispose();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose() => Dispose(true);

    }
}