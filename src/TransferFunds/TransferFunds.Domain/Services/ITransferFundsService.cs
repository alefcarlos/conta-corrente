using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TransferFunds.Domain.Services
{
    public interface ITransferFundsService
    {
        Task<ValidationResult> TransferAsync(Guid from, Guid to, decimal value, CancellationToken cancellationToken);
    }
}
