using Account.Application.Commands;
using Account.Application.Queries;
using Account.Domain.Entities;
using Account.WebApi.Contracts;
using Framework.WebAPI;
using Framework.WebAPI.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        /// <summary>
        /// Obtém as transações de uma determinada conta corrente.
        /// </summary>
        /// <param name="account_id">ID da conta</param>
        [HttpGet("{account_id}/transactions")]
        [ProducesResponseType(typeof(PayloadResponse<List<GetTransactionsResponse>>), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        public async Task<IActionResult> GetTransactions([FromRoute]Guid account_id)
        {
            var response = await mediator.Send(new TransactionsByAccount(account_id));

            if (response.Invalid)
                return ValidationError(response);

            var transactions = response.Result as List<TransactionEntity>;

            var result = transactions.Select(tr => new GetTransactionsResponse(tr)).ToList();

            return Ok(PayloadResponse<List<GetTransactionsResponse>>.Create(result));
        }

        /// <summary>
        /// Gera uma nova transação para uma determinada conta
        /// </summary>
        /// <param name="request">Dados da transação</param>
        /// <param name="account_id">ID da conta</param>
        [HttpPost("{account_id}/transactions")]
        [ProducesResponseType(typeof(PayloadResponse), 201)]
        public async Task<IActionResult> PosTransaction([FromRoute]Guid account_id, [FromBody] PostTransactionRequest request)
        {
            var response = await mediator.Send(new PublishTransaction(account_id, request.Value, request.Type));

            if (response.Invalid)
                return ValidationError(response);

            return Created("", PayloadResponse.Create());
        }

        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(PayloadResponse<AccountEntity>), 201)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
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
