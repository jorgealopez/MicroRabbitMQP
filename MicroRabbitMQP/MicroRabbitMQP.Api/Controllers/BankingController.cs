using System.Collections.Generic;
using MicroRabbitMQP.Banking.Application.Interfaces;
using MicroRabbitMQP.Banking.Application.Models;
using MicroRabbitMQP.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbitMQP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}