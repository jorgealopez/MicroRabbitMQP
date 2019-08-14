using System.Collections.Generic;
using MicroRabbitMQP.Banking.Domain.Models;

namespace MicroRabbitMQP.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}