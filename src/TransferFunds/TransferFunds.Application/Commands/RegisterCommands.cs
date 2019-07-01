using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TransferFunds.Application.Commands
{
    public static class RegisterCommands
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Transfer));

            return services;
        }
    }
}