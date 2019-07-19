using Account.Domain.Enums;
using Account.Domain.Events;
using Flunt.Notifications;
using Framework.CQRS.Commands;
using System;

namespace Account.Application.Commands
{
    public class CreateTransaction : Notifiable, ICommand
    {

        public CreateTransaction(TransactionEvent message)
        {
            AccountId = message.AccountId;
            Date = message.Date;
            Value = message.Value;
            Type = message.Type;
        }

        public CreateTransaction(Guid accountId, decimal value, ETransactionType type, DateTime date)
        {
            AccountId = accountId;
            Date = date;
            Value = value;
            Type = type;
        }

        public Guid AccountId { get; }

        /// <summary>
        /// Data e hora da transação
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public ETransactionType Type { get; }
    }
}
