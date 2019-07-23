using Flunt.Notifications;
using Framework.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.CQRS.Pipelines
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : Notifiable, IRequest<TResponse>
            where TResponse : Response, new()
    {
        public FailFastRequestBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        private readonly ILogger logger;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            logger.LogInformation($"Validating {typeof(TRequest).Name}");

            if (request.Invalid)
            {
                var response = new TResponse();
                response.AddNotifications(request.Notifications);
                return Task.FromResult(response as TResponse);
            }

            return next();
        }
    }
}
