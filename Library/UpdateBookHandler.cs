using Events.pkg.events.interfaces;
using Library.Entities;
using Library.Events;

namespace Library;

public class UpdateBookHandler
{
    private readonly IEventDispatcherInterface _eventDispatcher;

    public UpdateBookHandler(IEventDispatcherInterface eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }

    public void Handle(Book book, string newTitle, string newAuthor, DateTime newPublishedDate)
    {
        book.SetTitle(newTitle);
        book.SetAuthor(newAuthor);
        book.SetPublishedDate(newPublishedDate);

        var bookUpdatedEvent = new BookUpdatedEvent(book);
        _eventDispatcher.Dispatch(bookUpdatedEvent);
    }
}