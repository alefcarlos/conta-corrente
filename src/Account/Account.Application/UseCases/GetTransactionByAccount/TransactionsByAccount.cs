using System;

namespace Account.Application.Queries
{
    public class TransactionsByAccount
    {
        public TransactionsByAccount(Guid id)
        {
            this.ID = id;

        }
        public Guid ID { get; }
    }
}