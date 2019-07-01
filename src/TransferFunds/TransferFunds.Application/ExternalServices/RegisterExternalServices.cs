using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using System;
using System.Net;
using System.Net.Http;
using TransferFunds.Application.Settings;

namespace TransferFunds.Application.ExternalServices
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            var settings = new AccountSettings
            {
                URI = Environment.GetEnvironmentVariable("ACCOUNT_URI")
            };

            services.AddSingleton(settings);

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            //Serviços HTTP
            services.AddHttpClient<AccountService>()
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(timeoutPolicy);


            return services;
        }

        /// <summary>
        ///  É adicionado uma política para tentar 3 vezes com uma repetição exponencial, começando em um segundo.
        /// </summary>
        /// <returns></returns>
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.InternalServerError)
                .Or<TimeoutRejectedException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)));
        }
    }
}
