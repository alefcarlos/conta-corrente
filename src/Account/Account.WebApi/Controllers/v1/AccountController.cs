using Account.Domain.Contracts;
using Account.Domain.Entities;
using Account.Domain.Services;
using Framework.WebAPI;
using Framework.WebAPI.Responses;
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
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public AccountController(IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }

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
            var (Err, Entity) = await _accountService.GetByIdentifierAsync(identifier);
            if (!Err.IsValid)
                return ValidationError(Err);

            return Ok(PayloadResponse<GetAccountResponse>.Create(new GetAccountResponse(Entity)));
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
        public async Task<IActionResult> GetBalance(Guid account_id)
        {
            var result = await _transactionService.GetBalanceAsync(account_id);

            return Ok(PayloadResponse<decimal>.Create(result));
        }


        /// <summary>
        /// Obtém as transações de uma determinada conta corrente.
        /// </summary>
        /// <param name="account_id">ID da conta</param>
        [HttpGet("{account_id}/transactions")]
        [ProducesResponseType(typeof(PayloadResponse<List<GetTransactionsResponse>>), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        public async Task<IActionResult> GetTransactions(Guid account_id)
        {
            var transactions = await _transactionService.GetTransactionsAsync(account_id);

            var result = transactions.Select(tr => new GetTransactionsResponse(tr)).ToList();

            return Ok(PayloadResponse<List<GetTransactionsResponse>>.Create(result));
        }

        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(PayloadResponse<Guid>), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAccountRequest request)
        {
            var entity = new AccountEntity(request);
            await _accountService.CreateAsync(entity);

            return Ok(PayloadResponse<Guid>.Create(entity.AccountId));
        }
    }
}
