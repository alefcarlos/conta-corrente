using System.Collections.Generic;
using System.Linq;

namespace Framework.Shared
{
    public class ErrorResult
    {
        public ErrorResult()
        {
            Errors = new List<string>();
        }

        public bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        public IList<string> Errors { get; set; }

        public void Add(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
                return;

            Errors.Add(error);
        }

        public static ErrorResult Valid() => new ErrorResult();
    }
}
