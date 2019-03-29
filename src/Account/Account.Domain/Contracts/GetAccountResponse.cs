using Account.Domain.Entities;

namespace Account.Domain.Contracts
{
    /// <summary>
    /// Response de conta corrent
    /// </summary>
    public class GetAccountResponse
    {
        public GetAccountResponse(AccountEntity entity)
        {
            Name = entity.Name;
            CPF = entity.CPF;
        }

        /// <summary>
        /// Nome da conta corrente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Documento de identifica��o
        /// </summary>
        public string CPF { get; set; }
    }
}