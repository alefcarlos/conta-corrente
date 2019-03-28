using Framework.Shared;
using Framework.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Framework.WebAPI
{
    public class BaseController : ControllerBase
    {
        protected BadRequestObjectResult ValidationError(ErrorResult validation)
        {
            return BadRequest(PayloadResponse<List<string>>.Create(validation.Errors, false));
        }
    }
}
