using Account.Domain.Data.Repositories;
using Account.Domain.Entities;
using Account.Domain.Services;
using Account.PublicShared.Events;
using Framework.MessageBroker.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _repo;
        private readonly IRabbitMQPublisher _publisher;

        public TransactionService(ITransactionRepository repo, IRabbitMQPublisher publisher)
        {
            _repo = repo;
            _publisher = publisher;
        }

        public async Task<List<TransactionEntity>> GetTransactionsAsync(Guid accountId) => await _repo.ReadAsync(tr => tr.AccountId == accountId);

        public async Task<decimal> GetBalanceAsync(Guid accountId) => (await _repo.ReadAsync(tr => tr.AccountId == accountId)).Sum(x => x.Value);

        //public async Task PostTransactionAsync(Guid accountId, PostTransactionRequest request)
        //{
        //    var @event = new TransactionEvent(accountId, request.Value, request.Type);
        //    await _publisher.PublishAsync(@event);
        //}
    }
}
