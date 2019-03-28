using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.TransferFunds.Controllers
{
    /// <summary>
    /// Controller para operações entre contas
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TransferController : ControllerBase
    {
        /// <summary>
        /// Realiza uma transfêrecia entre contas
        /// </summary>
        /// <param name="request">Dados da transfêrencia</param>
        [HttpPost()]
        public IActionResult Post(PostTransFunderRequest request)
        {
            var result = PayloadResponse.Create(true);
            return Ok(result);
        }
    }

    /// <summary>
    /// Request de transfêrencia de fundos entre contas
    /// </summary>
    public class PostTransFunderRequest
    {
        /// <summary>
        /// Conta de origem
        /// </summary>
        public Guid From { get; set; }

        /// <summary>
        /// Conta de destino
        /// </summary>
        public Guid To { get; set; }

        /// <summary>
        /// Valor a ser transferido
        /// </summary>
        public decimal Value { get; set; }
    }
}
