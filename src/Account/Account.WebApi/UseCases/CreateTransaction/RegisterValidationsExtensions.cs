using Account.WebApi.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Account.WebApi.Validations
{
    public static class RegisterCreateTransactionValidationsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            // can then manually register validators
            services.AddTransient<IValidator<PostTransactionRequest>, PostTransactionRequestValidator>();

            return services;
        }
    }
}
