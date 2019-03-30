using Framework.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using TransferFunds.Application.Services;
using TransferFunds.Application.Settings;

namespace TransferFunds.Application.Tests
{
    public class Startup : TestStartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            var settings = new AccountSettings
            {
                URI = Environment.GetEnvironmentVariable("ACCOUNT_URI")
            };

            services.AddSingleton(settings);

            //Serviços HTTP
            services.AddHttpClient<AccountService>();
        }
    }
}
