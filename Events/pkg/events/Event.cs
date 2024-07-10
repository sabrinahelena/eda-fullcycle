using Events.pkg.events.interfaces;

namespace Events.pkg.events;

public class Event : IEventInterface
{
    private string name;

    public Event(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public DateTime GetDateTime()
    {
        return DateTime.Now;
    }

    public object GetPayload()
    {
        return null;
    }
}
