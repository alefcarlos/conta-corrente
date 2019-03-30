using Account.PublicShared.Events;
using Framework.MessageBroker.RabbitMQ;
using Framework.Shared;
using System;
using System.Threading.Tasks;
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
            try
            {
                await _accountService.GetAccountByIDAsync(from);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                validation.Add("A conta de origem não existe!");
                return validation;
            }

            try
            {
                await _accountService.GetAccountByIDAsync(to);
            }
            catch (System.Net.Http.HttpRequestException)
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
            await _publisher.PublishAsync(new TransactionEvent(from, -value, Account.PublicShared.Enums.ETransactionType.Transfer));
            await _publisher.PublishAsync(new TransactionEvent(to, value, Account.PublicShared.Enums.ETransactionType.Transfer));

            return validation;
        }
    }
}
