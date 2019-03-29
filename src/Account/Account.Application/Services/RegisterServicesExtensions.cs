using Microsoft.Extensions.DependencyInjection;
using Account.Domain.Services;

namespace Account.Application.Services
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
