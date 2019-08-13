using System.Threading.Tasks;
using MicroRabbitMQP.Domain.Core.Commands;
using MicroRabbitMQP.Domain.Core.Events;

namespace MicroRabbitMQP.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}