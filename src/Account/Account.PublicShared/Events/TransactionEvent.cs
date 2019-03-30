using Account.PublicShared.Contracts;
using Account.PublicShared.Enums;
using Framework.MessageBroker;
using Framework.MessageBroker.RabbitMQ;
using System;

namespace Account.PublicShared.Events
{
    [RabbitMQProperties(Durable = true)]
    public class TransactionEvent : BaseMessage
    {
        public TransactionEvent(Guid accountId, decimal value, ETransactionType type)
        {
            AccountId = accountId;
            Date = DateTime.Now;
            Value = value;
            Type = type;
        }

        public TransactionEvent(Guid accountId, PostTransactionRequest request)
        {
            AccountId = accountId;
            Date = DateTime.Now;
            Value = request.Value;
            Type = request.Type;
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
