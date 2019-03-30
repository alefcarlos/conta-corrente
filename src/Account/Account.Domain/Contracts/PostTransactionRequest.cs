using Account.PublicShared.Enums;

namespace Account.Domain.Contracts
{
    /// <summary>
    /// Request de transação
    /// </summary>
    public class PostTransactionRequest
    {
        /// <summary>
        /// Valor transacionado
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Tipo da transação
        /// </summary>
        public ETransactionType Type { get; set; }
    }
}
