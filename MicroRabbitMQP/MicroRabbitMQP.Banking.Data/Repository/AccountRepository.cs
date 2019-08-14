using System.Collections.Generic;
using MicroRabbitMQP.Banking.Data.Context;
using MicroRabbitMQP.Banking.Domain.Interfaces;
using MicroRabbitMQP.Banking.Domain.Models;

namespace MicroRabbitMQP.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }
    }
}