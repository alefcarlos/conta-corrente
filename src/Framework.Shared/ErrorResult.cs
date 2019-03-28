using System.Collections.Generic;

namespace Framework.Shared
{
    public class ErrorResult
    {
        public ErrorResult()
        {
            Errors = new List<string>();
        }

        public bool IsValid { get; set; }

        public IList<string> Errors { get; set; }

        public void Add(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
                return;

            Errors.Add(error);
        }
    }
}
