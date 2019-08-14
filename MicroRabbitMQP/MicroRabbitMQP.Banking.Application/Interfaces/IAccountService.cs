using System.Collections.Generic;
using MicroRabbitMQP.Banking.Application.Models;
using MicroRabbitMQP.Banking.Domain.Models;

namespace MicroRabbitMQP.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void Transfer(AccountTransfer accountTransfer);
    }
}