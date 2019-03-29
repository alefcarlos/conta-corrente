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
        }


        /// <summary>
        /// Nome da conta corrente
        /// </summary>
        public string Name { get; set; }
    }
}