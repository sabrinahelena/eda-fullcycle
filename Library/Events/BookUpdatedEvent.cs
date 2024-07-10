using Events.pkg.events.interfaces;
using Library.Entities;

namespace Library.Events;

public class BookUpdatedEvent : IEventInterface
{
    public Book Book { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public BookUpdatedEvent(Book book)
    {
        Book = book;
        UpdatedAt = DateTime.Now;
    }

    public string GetName() => "BookUpdatedEvent";

    public DateTime GetDateTime() => UpdatedAt;

    public object GetPayload() => Book;
}