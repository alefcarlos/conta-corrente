using System;

namespace TransferFunds.Domain.Events
{
    public class TransferFundsEvent
    {
        public TransferFundsEvent(Guid from, Guid to, decimal value)
        {
            From = from;
            To = to;
            Value = value;
        }

        /// <summary>
        /// Conta de origem
        /// </summary>
        public Guid From { get; private set; }

        /// <summary>
        /// COnta de destino
        /// </summary>
        public Guid To { get; private set; }

        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get; private set; }
    }
}