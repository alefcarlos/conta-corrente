using System.Threading;
using System.Threading.Tasks;
using Account.Application.Commands;
using Account.Domain.Events;
using Framework.MessageBroker.RabbitMQ;
using Framework.Shared;
using MediatR;

namespace Account.Application.Handlers.Commands
{
    public class PublishTransactionHandler : IRequestHandler<PublishTransaction, Response>
    {
        private readonly IRabbitMQPublisher _publisher;

        public PublishTransactionHandler(IRabbitMQPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task<Response> Handle(PublishTransaction request, CancellationToken cancellationToken)
        {
           var @event = new TransactionEvent(request.AccountId, request.Date, request.Value, request.Type);
           await _publisher.PublishAsync(@event);

           return new Response();
        }
    }
}