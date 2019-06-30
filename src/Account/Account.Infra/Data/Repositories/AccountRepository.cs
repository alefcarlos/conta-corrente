using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Framework.Data.MongoDB;

namespace Account.Infra.Data.Repositories
{
    public class AccountRepository : MongoRepositoryBase<AccountEntity>, IAccountRepository
    {
        public AccountRepository(MongoDBConnectionWraper connection) : base(connection)
        {
        }
    }
}
