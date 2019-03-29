
using System;
using System.Collections.Generic;
using System.Text;

namespace TransferFunds.Domain.Entities
{
    /// <summary>
    /// Entidade de transação de valores entre contas
    /// </summary>
    public class TransactionEntity
    {
        /// <summary>
        /// Constante do tipo da transação
        /// </summary>
        public const int TRANSACTION_TYPE_TRASNFER = 0;

        public TransactionEntity(Guid from, Guid to, decimal value)
        {
            Date = DateTime.Now;
            From = from;
            To = to;
            Value = value;
            Type = TRANSACTION_TYPE_TRASNFER;
        }

        /// <summary>
        /// Conta de origem
        /// </summary>
        public Guid From { get; private  set; }

        /// <summary>
        /// COnta de destino
        /// </summary>
        public Guid To { get; private  set; }

        /// <summary>
        /// Data e hora da transação
        /// </summary>
        public DateTime Date { get; private  set; }

        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public int Type { get; private set; }
    }
}
