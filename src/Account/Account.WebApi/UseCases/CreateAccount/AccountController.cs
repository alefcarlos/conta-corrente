using Account.Domain.Entities;
using Account.WebApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using PlusUltra.WebApi.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Account.UseCases.CreateAccount
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
        /// Cria uma nova conta corrente
        /// </summary>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(AccountEntity), 201)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAccountRequest request)
        {
            var response = await mediator.Send(new CreateAccount(request.Name, request.CPF));

            if (response.Invalid)
                return ValidationError(response);

            return Created("", response.Result);
        }
    }
}
