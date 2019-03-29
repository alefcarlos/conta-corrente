using Microsoft.Extensions.DependencyInjection;
using Account.Domain.Data.Repositories;

namespace Account.Application.Data.Repositories
{
    public static class RegisterRepositoriesExtensions
    {
        public static IServiceCollection AddMongoRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
