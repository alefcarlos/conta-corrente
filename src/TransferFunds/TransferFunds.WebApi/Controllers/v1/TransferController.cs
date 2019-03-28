using Framework.WebApi.Extensions;
using Framework.WebAPI;
using Framework.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransferFunds.Domain.Contracts;
using TransferFunds.Domain.Services;

namespace WebApi.TransferFunds.Controllers.v1
{
    /// <summary>
    /// Controller para operações entre contas
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TransferController : BaseController
    {
        private readonly ITransferFundsService _service;

        public TransferController(ITransferFundsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Realiza uma transferência entre contas
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST v1/transfer
        ///     {
        ///       "from": "3c4b4c86-d893-4d7c-98c4-2165ba59063d",
        ///       "to": "60f71848-49e2-4b6b-a796-0187583f7c4d",
        ///       "value": 50.30
        ///     }
        /// </remarks>
        /// <param name="request">Dados da transfêrencia</param>
        [HttpPost]
        [ProducesResponseType(typeof(PayloadResponse), 200)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        public async Task<IActionResult> Post(PostTransferFundsRequest request, CancellationToken cancellationToken)
        {
            var transfer = await _service.TransferAsync(request.From, request.To, request.Value, cancellationToken);

            if (!transfer.IsValid)
                return ValidationError(transfer);

            return Ok(PayloadResponse.Create(true));
        }
    }
}

