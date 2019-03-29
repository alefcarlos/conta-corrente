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
using Account.Domain.Contracts;

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
        private readonly IBalanceService _balanceService;
        private readonly IAccountService _accountService;

        public AccountController(IBalanceService service, IAccountService accountService)
        {
            _balanceService = service;
            _accountService = accountService;
        }

        /// <summary>
        /// Obtém uma conta corrente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET v1/account/30039ca2-675b-4a12-bd2d-a4daf1be4ecb
        /// </remarks>
        /// <param name="account_id">ID da conta</param>
        [HttpGet("{account_id}")]
        [ProducesResponseType(typeof(PayloadResponse<GetAccountResponse>), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        public async Task<IActionResult> Get(Guid account_id, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetByIdAsync(account_id, cancellationToken);
            if (!result.Err.IsValid)
                return ValidationError(result.Err);


            return Ok(PayloadResponse<GetAccountResponse>.Create(new GetAccountResponse(result.Entity)));
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
            var result = await _balanceService.GetAccountBallanceAsync(account_id, cancellationToken);

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
