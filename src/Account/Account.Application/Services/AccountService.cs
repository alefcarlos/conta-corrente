using Account.Domain.Entities;
using Account.Domain.Services;
using Framework.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Application.Services
{
    public class AccountService : IAccountService
    {
        public async Task<(ErrorResult Err, AccountEntity Entity)> GetByIdAsync(Guid accountId)
        {
            var validation = ErrorResult.Valid();

            //Obter registro do repositório

            return (validation, new AccountEntity() { Name = "Alef" });
        }
    }
}