using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TransferFunds.WebApi.Contracts;

namespace TransferFunds.WebApi.Validations
{
    public static class RegisterValidationsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            // can then manually register validators
            services.AddTransient<IValidator<PostTransferFundsRequest>, PostTransferFundsRequestValidator>();
                
            return services;
        }
    }
}
