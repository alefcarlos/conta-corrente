using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Application.Commands
{
    public static class RegisterCommands
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateAccount));

            AssemblyScanner.FindValidatorsInAssembly(typeof(RegisterCommands).Assembly)
                            .ForEach(result =>
                            {
                                services.AddTransient(result.InterfaceType, result.ValidatorType);
                            }
                );

            return services;
        }
    }
}
