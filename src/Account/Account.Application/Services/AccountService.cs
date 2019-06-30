using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Account.Domain.Services;
using Framework.Shared;
using System;
using System.Threading.Tasks;

namespace Account.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task CreateAsync(AccountEntity entity) => _accountRepository.CreateAsync(entity);

        public async Task<(Response Err, AccountEntity Entity)> GetByIdAsync(Guid accountId)
        {
            var validation = new Response();

            //Obter registro do repositório
            var result = await _accountRepository.ReadFirstOrDefaultAsync(x => x.AccountId == accountId);
            if (result == null)
                validation.AddNotification("Conta", "Conta não encontrada.");

            return (validation, result);
        }

        public async Task<(Response Err, AccountEntity Entity)> GetByIdentifierAsync(string identifier)
        {
            var validation = new Response();

            //validar tipo de identificador
            if (Guid.TryParse(identifier, out Guid parsed))
            {
                var entity = await _accountRepository.ReadFirstOrDefaultAsync(x => x.AccountId == parsed);
                if (entity == null)
                    validation.AddNotification("Conta", "Conta não encontrada.");

                return (validation, entity);
            }

            //Então é um CPF
            var account = await _accountRepository.ReadFirstOrDefaultAsync(x => x.CPF == identifier);
            if (account == null)
                validation.AddNotification("Conta", "Conta não encontrada.");

            return (validation, account);
        }
    }
}