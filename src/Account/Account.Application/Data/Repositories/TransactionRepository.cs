using Framework.Data.MongoDB;
using Account.Domain.Data.Repositories;
using Account.Domain.Entities;

namespace Account.Application.Data.Repositories
{
    public class TransactionRepository : MongoRepositoryBase<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(MongoDBConnectionWraper connection) : base(connection)
        {
        }
    }
}
