using System.Collections.Generic;
using MicroRabbitMQP.Banking.Application.Interfaces;
using MicroRabbitMQP.Banking.Application.Models;
using MicroRabbitMQP.Banking.Domain.Commands;
using MicroRabbitMQP.Banking.Domain.Interfaces;
using MicroRabbitMQP.Banking.Domain.Models;
using MicroRabbitMQP.Domain.Core.Bus;

namespace MicroRabbitMQP.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            _bus.SendCommand(createTransferCommand);
        }
    }
}