using Account.Domain.Data.Repositories;
using Account.Domain.Entities;
using Account.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _repo;

        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TransactionEntity>> GetTransactionsAsync(Guid accountId) => await _repo.ReadAsync(tr => tr.AccountId == accountId);
    }
}
