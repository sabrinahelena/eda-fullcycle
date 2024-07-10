using Events.pkg.events.interfaces;

namespace Events.pkg.events;

public class EventHandler : IEventHandlerInterface
{
    public void Handle(IEventInterface eventInstance)
    {
        Console.WriteLine($"Event {eventInstance.GetName()} handled at {eventInstance.GetDateTime()}");
    }
}
