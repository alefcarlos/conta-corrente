using Microsoft.Extensions.DependencyInjection;
using TransferFunds.Domain.Services;

namespace TransferFunds.Application.Services
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITransferFundsService, TransferFundsService>();

            //Serviços HTTP
            services.AddHttpClient<AccountService>();

            return services;
        }
    }
}
