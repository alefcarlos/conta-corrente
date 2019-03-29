using Framework.MessageBroker.RabbitMQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TransferFunds.Domain.Events;

namespace TransferFunds.Application.EventHandlers
{
    public class TransferFundsHandler : IHostedService
    {
        private readonly IRabbitMQSubscriber _subscriber;
        private readonly ILogger _logger;

        public TransferFundsHandler(IRabbitMQSubscriber subscriber, ILogger<TransferFundsHandler> logger)
        {
            _subscriber = subscriber;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Realizar bind do consummo da fila
            _subscriber.StartConsume<TransferFundsEvent>(ConsumeEvent);
            return Task.CompletedTask;
        }

        private bool ConsumeEvent(TransferFundsEvent message)
        {
            //Persistir duas transações na tabela(Crédito no destino e Débito na Origem)
            _logger.LogInformation($"Persistindos transações.");



            //Emitir evento de re-cálculo de saldo para ambas contas
            _logger.LogInformation($"Emitindo evento de recálculo de Saldo.");
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscriber.Dispose();
            return Task.CompletedTask;
        }
    }
}
