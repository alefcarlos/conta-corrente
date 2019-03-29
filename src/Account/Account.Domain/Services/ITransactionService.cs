using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Domain.Services
{
    public interface ITransactionService
    {
        Task<List<TransactionEntity>> GetTransactionsAsync(Guid account_id);
    }
}
