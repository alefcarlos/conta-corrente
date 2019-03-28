using FluentValidation.Results;
using Framework.WebApi.Extensions;
using Framework.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Framework.WebAPI
{
    public class BaseController : ControllerBase
    {
        protected BadRequestObjectResult ValidationError(ValidationResult validation)
        {
            return BadRequest(PayloadResponse<List<string>>.Create(validation.ExtractErrorsFromResult(), false));
        }
    }
}
