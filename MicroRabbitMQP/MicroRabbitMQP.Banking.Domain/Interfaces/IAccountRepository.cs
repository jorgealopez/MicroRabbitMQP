using System.Collections.Generic;
using MicroRabbitMQP.Banking.Domain.Models;

namespace MicroRabbitMQP.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}