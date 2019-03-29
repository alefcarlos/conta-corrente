using Account.Domain.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Domain.Validations
{
    public static class RegisterValidationsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            // can then manually register validators
            services.AddTransient<IValidator<PostAccountRequest>, PostAccountRequestValidator>();

            return services;
        }
    }
}
