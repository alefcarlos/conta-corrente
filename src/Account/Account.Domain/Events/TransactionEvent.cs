using Account.Domain.Enums;
using System;

namespace Account.Domain.Events
{
    public class TransactionEvent
    {
        public TransactionEvent()
        {

        }

        public TransactionEvent(Guid accountId, DateTime date, decimal value, ETransactionType type)
        {
            AccountId = accountId;
            Date = date;
            Value = value;
            Type = type;
        }

        public Guid AccountId { get; set; }

        /// <summary>
        /// Data e hora da transação
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public ETransactionType Type { get; set; }
    }
}
