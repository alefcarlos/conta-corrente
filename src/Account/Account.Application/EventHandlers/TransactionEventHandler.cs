using Account.Domain.Data.Repositories;
using Account.Domain.Entities;
using Account.PublicShared.Events;
using Framework.MessageBroker.RabbitMQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.EventHandlers
{
    public class TransactionEventHandler : IHostedService
    {
        private readonly IRabbitMQSubscriber _subscriber;
        private readonly ILogger _logger;
        private readonly ITransactionRepository _repository;

        public TransactionEventHandler(IRabbitMQSubscriber subscriber, ILogger<TransactionEventHandler> logger, ITransactionRepository repository)
        {
            _subscriber = subscriber;
            _logger = logger;
            _repository = repository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Realizar bind do consummo da fila
            _subscriber.StartConsume<TransactionEvent>(ConsumeEvent);
            return Task.CompletedTask;
        }

        private bool ConsumeEvent(TransactionEvent message)
        {
            //Realizar double check se a conta existe


            _logger.LogInformation($"Persistir transação.");
            _repository.Create(new TransactionEntity(message));
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscriber.Dispose();
            return Task.CompletedTask;
        }
    }
}
