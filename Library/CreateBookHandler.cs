using Events.pkg.events.interfaces;
using Library.Entities;
using Library.Events;

namespace Library;

public class CreateBookHandler
{
    private readonly IEventDispatcherInterface _eventDispatcher;

    public CreateBookHandler(IEventDispatcherInterface eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }

    public void Handle(string title, string author, DateTime publishedDate)
    {
        var book = new Book(title, author, publishedDate);
        var bookCreatedEvent = new BookCreatedEvent(book);
        _eventDispatcher.Dispatch(bookCreatedEvent);
    }
}
