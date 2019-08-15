using System.Collections.Generic;
using MicroRabbitMQP.Domain.Core.Bus;
using MicroRabbitMQP.Transfer.Application.Interfaces;
using MicroRabbitMQP.Transfer.Domain.Interfaces;
using MicroRabbitMQP.Transfer.Domain.Models;

namespace MicroRabbitMQP.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}