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

namespace WebApi.Account.UseCases.CreateTransaction
{
    /// <summary>
    /// Controller para operações com ContaCorrente
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class AccountController : WebApiController
    {
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private readonly IMediator mediator;

        /// <summary>
        /// Gera uma nova transação para uma determinada conta
        /// </summary>
        /// <param name="request">Dados da transação</param>
        /// <param name="account_id">ID da conta</param>
        [HttpPost("{account_id}/transactions")]
        [ProducesResponseType(typeof(PayloadResponse), 201)]
        public async Task<IActionResult> PosTransaction([FromRoute] Guid account_id, [FromBody] PostTransactionRequest request)
        {
            var response = await mediator.Send(new PublishTransaction(account_id, request.Value, request.Type));

            if (response.Invalid)
                return ValidationError(response);

            return Created("", PayloadResponse.Create());
        }
    }
}
