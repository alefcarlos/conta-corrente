using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Framework.Shared;
using Framework.WebAPI;
using Framework.WebAPI.Responses;
using System.Threading;

namespace WebApi.Account.Controllers.v1
{
    /// <summary>
    /// Controller para operações com ContaCorrente
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IBalanceService _service;

        public AccountController(IBalanceService service)
        {
            _service = service;
        }

        [HttpGet("{account_id}")]
        public IActionResult Get(Guid account_id)
        {
            return Ok();
        }

        /// <summary>
        /// Obtém o saldo de um determinado usuário
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET v1/account/30039ca2-675b-4a12-bd2d-a4daf1be4ecb/balance
        /// </remarks>
        /// <param name="account_id">ID da conta</param>
        [ProducesResponseType(typeof(PayloadResponse<decimal>), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        [HttpGet("{account_id}/balance")]
        public async Task<IActionResult> GetBalance(Guid account_id, CancellationToken cancellationToken)
        {
            var result = await _service.GetAccountBallanceAsync(account_id, cancellationToken);

            if (!result.Err.IsValid)
                return ValidationError(result.Err);

            return Ok(PayloadResponse<decimal>.Create(result.Balance));
        }

        // POST v1/account/
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }
    }
}
