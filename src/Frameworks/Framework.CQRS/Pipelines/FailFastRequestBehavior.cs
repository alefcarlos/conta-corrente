using FluentValidation;
using FluentValidation.Results;
using Framework.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.CQRS.Pipelines
{
    /// <summary>
    /// https://medium.com/tableless/fail-fast-validations-com-pipeline-behavior-no-mediatr-e-asp-net-core-f3854d3c21fa
    /// </summary>
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : Response
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly ILogger _logger;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<FailFastRequestBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Validating {typeof(TRequest).Name}");

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
                _logger.LogError("Erros durante validação do command [{0}]", string.Join(" , ", failures.Select(f => f.ErrorMessage)));

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new Response();

            foreach (var failure in failures)
                response.AddNotification("Command", failure.ErrorMessage);

            return Task.FromResult(response as TResponse);
        }
    }
}
