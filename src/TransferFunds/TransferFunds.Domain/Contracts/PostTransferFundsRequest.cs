using System;

namespace TransferFunds.Domain.Contracts
{
    /// <summary>
    /// Request de transferência de valores entre contas
    /// </summary>
    public class PostTransferFundsRequest
    {
        /// <summary>
        /// Conta de origem
        /// </summary>
        public Guid From { get; set; }

        /// <summary>
        /// Conta de destino
        /// </summary>
        public Guid To { get; set; }

        /// <summary>
        /// Valor a ser transferido
        /// </summary>
        public decimal Value { get; set; }
    }
}
