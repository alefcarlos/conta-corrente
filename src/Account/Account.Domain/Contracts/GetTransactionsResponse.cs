using System;
using Account.Domain.Entities;
using Account.PublicShared.Enums;

namespace Account.Domain.Contracts
{
    public class GetTransactionsResponse
    {
        public GetTransactionsResponse(TransactionEntity entity)
        {
            Date = entity.Date;
            Value = entity.Value;
            Type = entity.Type;

        }

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
