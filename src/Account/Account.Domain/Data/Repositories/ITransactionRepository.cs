using Account.Domain.Entities;
using Framework.Data.MongoDB;

namespace Account.Domain.Data.Repositories
{
    public interface ITransactionRepository : IMongoRepositoryBase<TransactionEntity>
    {
    }
}
