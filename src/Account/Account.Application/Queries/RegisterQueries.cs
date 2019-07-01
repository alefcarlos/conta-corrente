using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Application.Queries
{
    public static class RegisterQueries
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AccountByIdentifier));
            services.AddMediatR(typeof(TransactionsByAccount));

            return services;
        }
    }
}
