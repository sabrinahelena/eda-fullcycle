namespace Events.pkg.events.interfaces;

/// <summary>
/// Dispatches events to their respective handlers.
/// </summary>
public interface IEventDispatcherInterface
{
    /// <summary>
    /// Registers a handler for a specific event name.
    /// </summary>
    /// <param name="eventName">The name of the event to handle.</param>
    /// <param name="handler">The handler that processes the event.</param>
    void Register(string eventName, IEventHandlerInterface handler);

    /// <summary>
    /// Dispatches an event to the appropriate handler.
    /// </summary>
    /// <param name="eventInstance">The event to dispatch.</param>
    void Dispatch(IEventInterface eventInstance);

    /// <summary>
    /// Removes a handler for a specific event name.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="handler">The handler to remove.</param>
    void Remove(string eventName, IEventHandlerInterface handler);

    /// <summary>
    /// Checks if a handler exists for a specific event name.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="handler">The handler to check.</param>
    /// <returns>True if the handler exists, otherwise false.</returns>
    bool Has(string eventName, IEventHandlerInterface handler);

    /// <summary>
    /// Clears all registered event handlers.
    /// </summary>
    void Clear();
}