using Framework.MessageBroker.RabbitMQ;
using Framework.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransferFunds.Domain.Events;
using TransferFunds.Domain.Services;

namespace TransferFunds.Application.Services
{
    public class TransferFundsService : ITransferFundsService
    {
        private readonly AccountService _accountService;
        private readonly IRabbitMQPublisher _publisher;

        public TransferFundsService(AccountService accountService, IRabbitMQPublisher publisher)
        {
            _accountService = accountService;
            _publisher = publisher;
        }

        public async Task<ErrorResult> TransferAsync(Guid from, Guid to, decimal value)
        {
            var validation = ErrorResult.Valid();

            //Validar contas
            var fromExists = await _accountService.ExistsAccountByIDAsync(from);

            if (!fromExists)
            {
                validation.Add("A conta de origem não existe!");
                return validation;
            }

            var toExists = await _accountService.ExistsAccountByIDAsync(from);

            if (!toExists)
            {
                validation.Add("A conta de destino não existe!");
                return validation;
            }

            //Validar saldo da conta de destino
            var fromBalance = await _accountService.GetAccountBalanceByIDAsync(from);
            if (fromBalance < value)
            {
                validation.Add("O saldo da conta de origem não é o suficiente pra realizar a transferência");
                return validation;
            }

            //Enviar evento de transferência entre contas
            await _publisher.PublishAsync(new TransferFundsEvent(from, to, value));

            return validation;
        }
    }
}
