using Microsoft.Extensions.Options;
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

        public RabbitMQConnectionWrapper(IOptions<RabbitSettings> settings)
        {
            disposed = false;
            _appName = settings.Value.ClientName;
            _rabbitUri = settings.Value.Uri;

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