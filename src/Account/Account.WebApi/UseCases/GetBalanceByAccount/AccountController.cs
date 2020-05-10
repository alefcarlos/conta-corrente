using Account.Application.Commands;
using Account.Application.Queries;
using Account.Domain.Entities;
using Account.WebApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using PlusUltra.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Account.UseCases.GetBalanceByAccount
{
    /// <summary>
    /// Controller para operações com ContaCorrente
    /// </summary>
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class AccountController : WebApiController
    {
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private readonly IMediator mediator;

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
        public async Task<IActionResult> GetBalance([FromRoute]Guid account_id)
        {
            var response = await mediator.Send(new TransactionsByAccount(account_id));

            if (response.Invalid)
                return ValidationError(response);

            var transactions = response.Result as List<TransactionEntity>;

            return Ok(PayloadResponse<decimal>.Create(transactions.Sum(x => x.Value)));
        }
    }
}
