using Account.PublicShared.Enums;
using Framework.MessageBroker;
using System;

namespace Account.PublicShared.Events
{
    public class TransactionEvent : BaseMessage
    {
        public TransactionEvent(Guid accountId, decimal value, ETransactionType type)
        {
            Date = DateTime.Now;
            Value = value;
            Type = type;
        }

        public Guid AccountId { get; private set; }

        /// <summary>
        /// Data e hora da transação
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public ETransactionType Type { get; private set; }
    }
}
