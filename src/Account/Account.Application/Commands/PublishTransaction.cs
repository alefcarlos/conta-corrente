using System;
using Account.Domain.Enums;
using Framework.CQRS.Commands;

namespace Account.Application.Commands
{
    public class PublishTransaction : ICommand
    {
        public PublishTransaction(Guid accountId, decimal value, ETransactionType type)
        {
            AccountId = accountId;
            Date = DateTime.Now;
            Value = value;
            Type = type;
        }

        public Guid AccountId { get; }

        /// <summary>
        /// Data e hora da transação
        /// </summary>
        public DateTime Date { get;  }

        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get;  }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public ETransactionType Type { get;  }
    }
}