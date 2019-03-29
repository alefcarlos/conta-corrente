using System;

namespace Account.Domain.Entities
{
    /// <summary>
    /// Entidade de saldo de conta corrente
    /// </summary>
    public class BalanceEntity
    {
        /// <summary>
        /// ID da conta
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Valor do saldo
        /// </summary>
        public decimal Balance { get; set; }
    }
}