using Framework.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransferFunds.Domain.Services
{
    public interface ITransferFundsService
    {
        Task<Response> TransferAsync(Guid from, Guid to, decimal value);
    }
}
