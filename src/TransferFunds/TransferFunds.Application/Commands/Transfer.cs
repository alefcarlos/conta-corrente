using System;
using Framework.CQRS.Commands;

namespace TransferFunds.Application.Commands
{
    public class Transfer : ICommand
    {
        public Transfer(Guid from, Guid to, decimal value)
        {
            From = from;
            To = to;
            Value = value;
        }

        /// <summary>
        /// Conta de origem
        /// </summary>
        public Guid From { get; }

        /// <summary>
        /// Conta de destino
        /// </summary>
        public Guid To { get; }

        /// <summary>
        /// Valor a ser transferido
        /// </summary>
        public decimal Value { get; }
    }
}