using Microsoft.Extensions.DependencyInjection;
using System;
using TransferFunds.Application.Settings;
using TransferFunds.Domain.Services;

namespace TransferFunds.Application.Services
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITransferFundsService, TransferFundsService>();

            var settings = new AccountSettings
            {
                URI = Environment.GetEnvironmentVariable("ACCOUNT_URI")
            };

            services.AddSingleton(settings);

            //Serviços HTTP
            services.AddHttpClient<AccountService>();

            return services;
        }
    }
}
