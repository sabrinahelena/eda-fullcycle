using Events.pkg.events.interfaces;
using Library.Entities;

namespace Library.Events;

public class BookCreatedEvent : IEventInterface
{
    public Book Book { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public BookCreatedEvent(Book book)
    {
        Book = book;
        CreatedAt = DateTime.Now;
    }

    public string GetName() => "BookCreatedEvent";

    public DateTime GetDateTime() => CreatedAt;

    public object GetPayload() => Book;
}