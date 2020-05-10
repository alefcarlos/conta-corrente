using Account.Domain.Entities;
using Account.Domain.Enums;
using System;

namespace Account.WebApi.Contracts
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
