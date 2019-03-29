using Framework.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TransferFunds.Domain.Services
{
    public interface ITransferFundsService
    {
        Task<ErrorResult> TransferAsync(Guid from, Guid to, decimal value);
    }
}
