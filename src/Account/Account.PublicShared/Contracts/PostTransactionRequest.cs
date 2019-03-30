using Account.PublicShared.Enums;
using System;

namespace Account.PublicShared.Contracts
{
    /// <summary>
    /// Request de transação
    /// </summary>
    public class PostTransactionRequest
    {
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
