using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TransferFunds.Domain.Contracts;

namespace TransferFunds.Domain.Validations
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
