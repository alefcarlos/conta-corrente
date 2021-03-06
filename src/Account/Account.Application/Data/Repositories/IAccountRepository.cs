﻿using Account.Domain.Entities;
using Framework.Data.MongoDB;

namespace Account.Application.Data.Repositories
{
    public interface IAccountRepository : IMongoRepositoryBase<AccountEntity>
    {
    }
}
