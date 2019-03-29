using Framework.Data.MongoDB;
using Account.Domain.Data.Repositories;
using Account.Domain.Entities;

namespace Account.Application.Data.Repositories
{
    public class AccountRepository : MongoRepositoryBase<AccountEntity>, IAccountRepository
    {
        public AccountRepository(MongoDBConnectionWraper connection) : base(connection)
        {
        }
    }
}
