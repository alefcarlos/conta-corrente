using Framework.WebAPI;
using Framework.WebAPI.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferFunds.Application.Commands;
using TransferFunds.WebApi.Contracts;

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
        public TransferController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private readonly IMediator mediator;

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
        [ProducesResponseType(typeof(PayloadResponse), 201)]
        [ProducesResponseType(typeof(PayloadResponse<List<string>>), 400)]
        public async Task<IActionResult> Post(PostTransferFundsRequest request)
        {
            var response = await mediator.Send(new Transfer(request.From, request.To, request.Value));

            if (response.Invalid)
                return ValidationError(response);

            return Ok(PayloadResponse.Create(true));
        }
    }
}

