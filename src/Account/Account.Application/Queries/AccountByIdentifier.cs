using Framework.CQRS.Queries;
using System;

namespace Account.Application.Queries
{
    public class AccountByIdentifier : IQuery
    {
        public string Identifier { get; }

        public string Document { get; set; }
        public Guid Id { get; }

        public AccountByIdentifier(string identifier)
        {
            //validar tipo de identificador
            if (Guid.TryParse(identifier, out Guid parsed))
                Id = parsed;
            else
                Document = identifier;
        }
    }
}
