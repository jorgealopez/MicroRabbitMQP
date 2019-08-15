using System.Threading.Tasks;
using MicroRabbitMQP.Domain.Core.Bus;
using MicroRabbitMQP.Transfer.Domain.Events;
using MicroRabbitMQP.Transfer.Domain.Interfaces;
using MicroRabbitMQP.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmmount = @event.Amount
            });
            return Task.CompletedTask;
        }
    }
}