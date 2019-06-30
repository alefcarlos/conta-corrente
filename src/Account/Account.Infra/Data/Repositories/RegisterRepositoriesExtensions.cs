using Account.Application.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Infra.Data.Repositories
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
