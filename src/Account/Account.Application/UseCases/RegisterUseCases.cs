using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Application.Commands
{
    public static class RegisterUseCases
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateAccount).Assembly);

            return services;
        }
    }
}
