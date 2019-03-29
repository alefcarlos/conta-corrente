using Account.Domain.Contracts;
using Framework.Data.MongoDB;
using System;

namespace Account.Domain.Entities
{
    /// <summary>
    /// Entidade de conta corrents
    /// </summary>
    public class AccountEntity : MongoEntityBase
    {
        public AccountEntity(PostAccountRequest request)
        {
            AccountId = Guid.NewGuid();
            Name = request.Name;
            CPF = request.CPF;
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