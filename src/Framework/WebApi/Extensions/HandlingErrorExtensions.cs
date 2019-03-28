using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Framework.WebApi.Extensions
{
    public static class HandlingErrorExtensions
    {
        public static List<string> ExtractErrorsFromResult(this ValidationResult validation)
        {
            if (validation.IsValid)
                return default(List<string>);

            return validation.Errors.Select(e => e.ErrorMessage).ToList();
        }
    }
}
