using Framework.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using TransferFunds.Application.ExternalServices;
using TransferFunds.Application.Settings;

namespace TransferFunds.Application.Tests
{
    public class Startup : TestStartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            var settings = new AccountSettings
            {
                Uri = Environment.GetEnvironmentVariable("ACCOUNT_URI")
            };

            services.AddSingleton(settings);

            //Serviços HTTP
            services.AddHttpClient<AccountService>();
        }
    }
}
