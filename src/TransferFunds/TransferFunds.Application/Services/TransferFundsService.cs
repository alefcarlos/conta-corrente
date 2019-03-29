using Framework.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransferFunds.Domain.Services;

namespace TransferFunds.Application.Services
{
    public class TransferFundsService : ITransferFundsService
    {
        private readonly AccountService _accountService;
        public TransferFundsService(AccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ErrorResult> TransferAsync(Guid from, Guid to, decimal value, CancellationToken cancellationToken)
        {
            var validation = ErrorResult.Valid();

            //Validar contas
            var fromExists = await _accountService.ExistsAccountByIDAsync(from, cancellationToken);

            if (!fromExists)
            {
                validation.Add("A conta de origem não existe!");
                return validation;
            }

            var toExists = await _accountService.ExistsAccountByIDAsync(from, cancellationToken);

            if (!toExists)
            {
                validation.Add("A conta de destino não existe!");
                return validation;
            }

            //Validar saldo da conta de destino
            var fromBalance = await _accountService.GetAccountBalanceByIDAsync(from, cancellationToken);
            if (fromBalance < value)
            {
                validation.Add("O saldo da conta de origem não é o suficiente pra realizar a transferência");
                return validation;
            }

            //Enviar evento de transferência

            return validation;
        }
    }
}
