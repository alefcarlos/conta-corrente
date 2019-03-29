using System;
using System.Threading;
using System.Threading.Tasks;
using Account.Domain.Entities;
using Framework.Shared;

namespace Account.Domain.Services
{
    public interface IAccountService
    {
        Task<(ErrorResult Err, AccountEntity Entity)> GetByIdAsync(Guid accountId, CancellationToken cancellationToken);
    }
}