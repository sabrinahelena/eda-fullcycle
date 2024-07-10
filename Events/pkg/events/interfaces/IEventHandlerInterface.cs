namespace Events.pkg.events.interfaces;

/// <summary>
/// Represents a handler for processing events.
/// </summary>
public interface IEventHandlerInterface
{
    /// <summary>
    /// Handles the given event.
    /// </summary>
    /// <param name="eventInstance">The event to handle.</param>
    void Handle(IEventInterface eventInstance);
}
