using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, THandler>()
            where T : Event
            where THandler : IEventHandler<T>;
    }
}