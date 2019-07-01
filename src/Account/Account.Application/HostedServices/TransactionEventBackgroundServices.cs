using Account.Application.Commands;
using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Account.Domain.Events;
using Framework.MessageBroker.RabbitMQ;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.HostedServices
{
    public class TransactionEventBackgroundServices : BackgroundService
    {
        private readonly IRabbitMQSubscriber _subscriber;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public TransactionEventBackgroundServices(IRabbitMQSubscriber subscriber, ILogger<TransactionEventBackgroundServices> logger, IMediator mediator)
        {
            _subscriber = subscriber;
            _logger = logger;
            _mediator = mediator;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Realizar bind do consummo da fila
            _subscriber.StartConsume<TransactionEvent>(ConsumeEvent);
            return Task.CompletedTask;
        }

        private bool ConsumeEvent(TransactionEvent message)
        {
            var result = _mediator.Send(new CreateTransaction(message)).Result;

            _logger.LogInformation($"Processado..");

            return result.Valid;
        }

        public override void Dispose()
        {
            _subscriber.Dispose();
            base.Dispose();
        }
    }
}
