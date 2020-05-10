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

namespace WebApi.Account.UseCases.GetAccountByIdentifier
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
        /// Obtém uma conta corrente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET v1/account/30039ca2-675b-4a12-bd2d-a4daf1be4ecb
        ///     GET v1/account/41469262894
        /// </remarks>
        /// <param name="identifier">Identificação da conta, CPF ou ID</param>
        [HttpGet("{identifier}")]
        [ProducesResponseType(typeof(PayloadResponse<GetAccountResponse>), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        public async Task<IActionResult> Get(string identifier)
        {
            var response = await mediator.Send(new AccountByIdentifier(identifier));

            if (response.Invalid)
                return ValidationError(response);

            return Ok(PayloadResponse<GetAccountResponse>.Create(new GetAccountResponse(response.Result as AccountEntity)));
        }
    }
}
