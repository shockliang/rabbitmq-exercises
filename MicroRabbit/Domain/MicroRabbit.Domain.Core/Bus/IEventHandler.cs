using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent: Event
    {
        Task Handler(TEvent @event);
    }

    public interface IEventHandler
    {
        
    }
}