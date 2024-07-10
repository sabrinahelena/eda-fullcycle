using Events.pkg.events.interfaces;

namespace Events.pkg.events;

public class EventDispatcher : IEventDispatcherInterface
{
    /// <summary>
    /// A dictionary that maps event names to lists of event handlers.
    /// The key is the event name as a string, and the value is a list of handlers that will process the event.
    /// </summary>
    private readonly Dictionary<string, List<IEventHandlerInterface>> handlers;

    public EventDispatcher()
    {
        handlers = [];
    }

    /// <summary>
    /// Registers a handler for a specific event name.
    /// </summary>
    /// <param name="eventName">The name of the event to handle.</param>
    /// <param name="handler">The handler that processes the event.</param>
    /// <exception cref="InvalidOperationException">Thrown when the handler is already registered for the event.</exception>
    public void Register(string eventName, IEventHandlerInterface handler)
    {
        //Verifica a existência da chave (nome do evento) 
        if (!handlers.ContainsKey(eventName))
        {
            handlers[eventName] = []; 
        }

        // Verifica se já existe um handler para aquele evento, se sim, duplicação geramos erro
        if (handlers[eventName].Contains(handler))
        {
            throw new InvalidOperationException("Handler already registered for this event.");
        }

        handlers[eventName].Add(handler);
    }

    /* Anotações
     * Handler é oque é chamado quando o evento ocorre, é o manipulador
     * O dicionário armazena os manipuladores de evento (handlers) pra podermos registrar, acessar, os handlers de cada evento
     */

    /// <summary>
    /// Dispatches an event to the appropriate handler.
    /// </summary>
    /// <param name="eventInstance">The event to dispatch.</param>
    public void Dispatch(IEventInterface eventInstance)
    {
        string eventName = eventInstance.GetName();
        if (handlers.ContainsKey(eventName))
        {
            foreach (var handler in handlers[eventName])
            {
                handler.Handle(eventInstance);
            }
        }
    }

    /// <summary>
    /// Removes a handler for a specific event name.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="handler">The handler to remove.</param>
    public void Remove(string eventName, IEventHandlerInterface handler)
    {
        if (handlers.ContainsKey(eventName))
        {
            handlers[eventName].Remove(handler);
            if (handlers[eventName].Count == 0)
            {
                handlers.Remove(eventName);
            }
        }
    }

    /// <summary>
    /// Checks if a handler exists for a specific event name.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="handler">The handler to check.</param>
    /// <returns>True if the handler exists, otherwise false.</returns>
    public bool Has(string eventName, IEventHandlerInterface handler)
    {
        return handlers.ContainsKey(eventName) && handlers[eventName].Contains(handler);
    }

    /// <summary>
    /// Clears all registered event handlers.
    /// </summary>
    public void Clear()
    {
        handlers.Clear();
    }
}
