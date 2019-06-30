using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Framework.CQRS
{
    public class Response
    {
        private readonly IList<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }

        public bool IsValid => !Errors.Any();

        public object Result { get; }

        public Response() => Errors = new ReadOnlyCollection<string>(_messages);

        public Response(object result) : this() => Result = result;

        public static Response Ok() => new Response();
        public static Response Ok(object result) => new Response(result);

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}
