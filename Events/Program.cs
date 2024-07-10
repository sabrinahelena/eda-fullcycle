using Events.pkg.events.interfaces;
using Events.pkg.events;
using EventHandler = Events.pkg.events.EventHandler;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventDispatcher eventDispatcher = new EventDispatcher();

            // Create a test event
            IEventInterface testEvent = new Event("TestEvent");

            // Create event handlers
            IEventHandlerInterface handler1 = new EventHandler();
            IEventHandlerInterface handler2 = new EventHandler();

            // Register handlers
            eventDispatcher.Register(testEvent.GetName(), handler1);
            eventDispatcher.Register(testEvent.GetName(), handler2);

            // Dispatch the event
            eventDispatcher.Dispatch(testEvent); 
        }
    }
}
