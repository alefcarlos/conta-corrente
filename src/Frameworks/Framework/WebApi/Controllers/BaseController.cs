using Framework.Shared;
using Framework.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Framework.WebAPI
{
    public class BaseController : ControllerBase
    {
        protected BadRequestObjectResult ValidationError(Response validation)
        {
            return BadRequest(PayloadResponse<List<string>>.Create(validation.Notifications, false));
        }
    }
}
