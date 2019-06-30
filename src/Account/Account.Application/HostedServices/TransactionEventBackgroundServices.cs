using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Account.PublicShared.Events;
using Framework.MessageBroker.RabbitMQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.EventHandlers
{
    public class TransactionEventBackgroundServices : BackgroundService
    {
        private readonly IRabbitMQSubscriber _subscriber;
        private readonly ILogger _logger;
        private readonly ITransactionRepository _repository;

        public TransactionEventBackgroundServices(IRabbitMQSubscriber subscriber, ILogger<TransactionEventBackgroundServices> logger, ITransactionRepository repository)
        {
            _subscriber = subscriber;
            _logger = logger;
            _repository = repository;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
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
            _logger.LogInformation($"Processado com sucesso!");
            return true;
        }

        public override void Dispose()
        {
            _subscriber.Dispose();
            base.Dispose();
        }
    }
}
