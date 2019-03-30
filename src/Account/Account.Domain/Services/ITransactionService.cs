﻿using Account.Domain.Contracts;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Domain.Services
{
    public interface ITransactionService
    {
        Task<List<TransactionEntity>> GetTransactionsAsync(Guid accountId);
        Task<decimal> GetBalanceAsync(Guid accountId);
        Task PostTransactionAsync(Guid accountId, PostTransactionRequest request);
    }
}
