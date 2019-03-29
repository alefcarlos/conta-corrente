using RabbitMQ.Client;
using System;

namespace Framework.MessageBroker.RabbitMQ
{
    public class RabbitMQConnectionWrapper : IDisposable
    {
        public IConnection Connection { get; private set; }

        private readonly string _appName;
        private readonly string _rabbitUri;

        private bool disposed;
        private ConnectionFactory factory = new ConnectionFactory();

        public RabbitMQConnectionWrapper(string appName, string rabbitUri)
        {
            disposed = false;
            _appName = appName;
            _rabbitUri = rabbitUri;

            factory.Uri = new Uri(_rabbitUri);
            factory.AutomaticRecoveryEnabled = true;
            factory.RequestedHeartbeat = 60;

            Connection = factory.CreateConnection(_appName);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Connection?.Close();
                    Connection?.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}