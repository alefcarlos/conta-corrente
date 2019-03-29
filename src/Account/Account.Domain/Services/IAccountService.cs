using Account.Domain.Entities;
using Framework.Shared;
using System;
using System.Threading.Tasks;

namespace Account.Domain.Services
{
    public interface IAccountService
    {
        Task<(ErrorResult Err, AccountEntity Entity)> GetByIdAsync(Guid accountId);
    }
}