namespace Events.pkg.events.interfaces;

/// <summary>
/// Represents an event with a name, date, and payload.
/// </summary>
public interface IEventInterface
{
    /// <summary>
    /// Gets the name of the event.
    /// </summary>
    /// <returns>The name of the event.</returns>
    string GetName();

    /// <summary>
    /// Gets the date and time of the event.
    /// </summary>
    /// <returns>The date and time of the event.</returns>
    DateTime GetDateTime();

    /// <summary>
    /// Gets the payload associated with the event.
    /// </summary>
    /// <returns>The payload of the event.</returns>
    object GetPayload();
}
