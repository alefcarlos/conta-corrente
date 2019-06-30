using Account.Domain.Enums;
using Framework.MessageBroker;
using Framework.MessageBroker.RabbitMQ;
using System;

namespace Account.Domain.Events
{
    [RabbitMQProperties(Durable = true)]
    public class TransactionEvent : BaseMessage
    {
        public TransactionEvent()
        {

        }

        public TransactionEvent(Guid accountId, decimal value, ETransactionType type)
        {
            AccountId = accountId;
            Date = DateTime.Now;
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
