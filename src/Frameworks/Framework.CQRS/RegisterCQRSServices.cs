using Framework.CQRS.Commands;
using Framework.CQRS.Pipelines;
using Framework.CQRS.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.CQRS
{
    public static class RegisterCQRSServices
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            return services;
        }
    }
}
