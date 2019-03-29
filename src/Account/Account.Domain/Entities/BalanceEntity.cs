using System;

namespace Account.Domain.Entities
{
    public class BalanceEntity
    {
        public Guid AccountId { get; set; }
        public decimal Balance { get; set; }
    }
}