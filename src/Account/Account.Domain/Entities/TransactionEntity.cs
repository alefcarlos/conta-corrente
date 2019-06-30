using Account.Domain.Enums;
using Account.Domain.Events;
using Framework.Data.MongoDB;
using System;

namespace Account.Domain.Entities
{
    /// <summary>
    /// Entidade de transação de valores entre contas
    /// </summary>
    public class TransactionEntity : MongoEntityBase
    {
        public TransactionEntity(TransactionEvent message)
        {
            AccountId = message.AccountId;
            Date = message.Date;
            Value = message.Value;
            Type = message.Type;
        }

        public TransactionEntity(Guid accountId, decimal value, ETransactionType type)
        {
            AccountId = accountId;
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
