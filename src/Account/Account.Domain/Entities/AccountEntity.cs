using System;

namespace Account.Domain.Entities
{
    /// <summary>
    /// Entidade de conta corrents
    /// </summary>
    public class AccountEntity
    {
        /// <summary>
        /// ID da conta
        /// </summary>
       public Guid ID { get; set; }

       /// <summary>
       /// Nome do correntista
       /// </summary>
       public string Name { get; set; }
    }
}