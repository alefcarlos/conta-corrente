using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Account.Controllers.v1
{
    /// <summary>
    /// Controller para operações com ContaCorrente
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET v1/account/{account_id}
        [HttpGet("{account_id}")]
        public IActionResult Get(Guid account_id)
        {
            return Ok();
        }

        // GET v1/account/{account_id}/balance
        [HttpGet("{account_id}/balance")]
        public async Task<IActionResult> GetBalance(Guid account_id)
        {
            return Ok();
        }

        // POST v1/account/
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }
    }
}
