using System;
using System.Threading;
using System.Threading.Tasks;
using Account.Domain.Enums;
using Account.Domain.Events;
using Framework.MessageBroker.RabbitMQ;
using Framework.Shared;
using MediatR;
using TransferFunds.Application.Commands;
using TransferFunds.Application.ExternalServices;

namespace TransferFunds.Application.Handlers
{

    public class TransferHandler : IRequestHandler<Transfer, Response>
    {
        private readonly AccountService _accountService;
        private readonly IRabbitMQPublisher _publisher;

        public TransferHandler(AccountService accountService, IRabbitMQPublisher publisher)
        {
            _accountService = accountService;
            _publisher = publisher;
        }
        public async Task<Response> Handle(Transfer request, CancellationToken cancellationToken)
        {
            var validation = new Response();

            //Validar contas
            try
            {
                await _accountService.GetAccountByIDAsync(request.From);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                validation.AddNotification("Transferência", "A conta de origem não existe!");
                return validation;
            }

            try
            {
                await _accountService.GetAccountByIDAsync(request.To);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                validation.AddNotification("Transferência", "A conta de destino não existe!");
                return validation;
            }

            //Validar saldo da conta de destino
            var fromBalance = await _accountService.GetAccountBalanceByIDAsync(request.From);
            if (fromBalance < request.Value)
            {
                validation.AddNotification("Transferência", "O saldo da conta de origem não é o suficiente pra realizar a transferência");
                return validation;
            }

            //Enviar evento de transferência entre contas
            await _publisher.PublishAsync(new TransactionEvent(request.From, DateTime.Now, -request.Value, ETransactionType.Transfer));
            await _publisher.PublishAsync(new TransactionEvent(request.To, DateTime.Now, request.Value, ETransactionType.Transfer));

            return validation;
        }
    }
}