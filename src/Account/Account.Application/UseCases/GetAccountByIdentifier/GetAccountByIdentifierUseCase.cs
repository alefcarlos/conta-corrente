using System;
using MediatR;

namespace Account.Application.Queries
{
    public class GetAccountByIdentifierUseCase : IRequest
    {
        public string Identifier { get; }

        public string Document { get; }
        public Guid Id { get; }

        public bool IsDocument => !string.IsNullOrWhiteSpace(Document);

        public GetAccountByIdentifierUseCase(string identifier)
        {
            //validar tipo de identificador
            if (Guid.TryParse(identifier, out Guid parsed))
                Id = parsed;
            else
                Document = identifier;
        }
    }
}
