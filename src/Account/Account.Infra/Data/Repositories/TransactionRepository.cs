using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Framework.Data.MongoDB;

namespace Account.Infra.Data.Repositories
{
    public class TransactionRepository : MongoRepositoryBase<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(MongoDBConnectionWraper connection) : base(connection)
        {
        }
    }
}
