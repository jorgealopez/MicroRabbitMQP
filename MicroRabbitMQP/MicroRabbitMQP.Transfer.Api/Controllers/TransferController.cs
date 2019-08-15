using System.Collections.Generic;
using MicroRabbitMQP.Transfer.Application.Interfaces;
using MicroRabbitMQP.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbitMQP.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}