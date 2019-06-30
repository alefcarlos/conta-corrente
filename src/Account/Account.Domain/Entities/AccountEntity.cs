using Framework.Data.MongoDB;
using System;

namespace Account.Domain.Entities
{
    /// <summary>
    /// Entidade de conta corrents
    /// </summary>
    public class AccountEntity : MongoEntityBase
    {
        public AccountEntity(string name, string cpf)
        {
            AccountId = Guid.NewGuid();
            Name = name;
            CPF = cpf;
        }

        /// <summary>
        /// ID da conta
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Nome do correntista
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Documento de identificação
        /// </summary>
        public string CPF { get; set; }
    }
}