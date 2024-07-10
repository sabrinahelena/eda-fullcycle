using Events.pkg.events;
using Events.pkg.events.interfaces;
using Library;

namespace LibraryConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEventDispatcherInterface eventDispatcher = new EventDispatcher();
            CreateBookHandler createBookHandler = new(eventDispatcher);

            // Register a handler to listen for book created events
            eventDispatcher.Register("BookCreatedEvent", new BookCreatedEventHandler());

            // Create a book
            createBookHandler.Handle("The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10));

            Console.WriteLine("Book creation process completed.");
        }
    }

    public class BookCreatedEventHandler : IEventHandlerInterface
    {
        public void Handle(IEventInterface eventInstance)
        {
            if (eventInstance is BookCreatedEvent bookCreatedEvent)
            {
                var book = (Book)bookCreatedEvent.GetPayload();
                Console.WriteLine($"Book Created: {book.Title} by {book.Author}, Published on {book.PublishedDate}");
            }
        }
    }
}
