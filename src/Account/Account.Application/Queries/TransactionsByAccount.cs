using System;
using Framework.CQRS.Queries;

namespace Account.Application.Queries
{
    public class TransactionsByAccount : IQuery
    {
        public TransactionsByAccount(Guid id)
        {
            this.ID = id;

        }
        public Guid ID { get; }
    }
}