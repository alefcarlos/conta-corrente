using System;
using System.Collections.Generic;
using System.Text;

namespace TransferFunds.Domain.Entities
{
    /// <summary>
    /// Entidade de transação de valores entre contas
    /// </summary>
    public class Transaction
    {
        public Transaction(Guid from, Guid to, decimal value)
        {
            Date = DateTime.Now;
            From = from;
            To = to;
            Value = value;
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
    }
}
