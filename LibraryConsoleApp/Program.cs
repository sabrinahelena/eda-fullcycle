using Events.pkg.events;
using Events.pkg.events.interfaces;
using Library;
using Library.Entities;
using Library.Events;

namespace LibraryConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEventDispatcherInterface eventDispatcher = new EventDispatcher();
            CreateBookHandler createBookHandler = new(eventDispatcher);
            UpdateBookHandler updateBookHandler = new UpdateBookHandler(eventDispatcher);


            // Register handlers
            var bookCreatedHandler = new BookCreatedEventHandler();
            var bookUpdatedHandler = new BookUpdatedEventHandler();

            // Register a handler to listen for book created events
            eventDispatcher.Register("BookCreatedEvent", bookCreatedHandler);
            eventDispatcher.Register("BookUpdatedEvent", bookUpdatedHandler);
            // Create a book
            createBookHandler.Handle("The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10));

            // Update the book
            Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10));
            updateBookHandler.Handle(book, "The Greatest Gatsby", "Fitzgerald", new DateTime(1926, 5, 10));




            // Remove book created handler
            eventDispatcher.Remove("BookCreatedEvent", bookCreatedHandler);

            // Try to create another book (the handler has been removed, so it won't be handled)
            createBookHandler.Handle("1984", "George Orwell", new DateTime(1949, 6, 8));

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

    public class BookUpdatedEventHandler : IEventHandlerInterface
    {
        public void Handle(IEventInterface eventInstance)
        {
            if (eventInstance is BookUpdatedEvent bookUpdatedEvent)
            {
                var book = (Book)bookUpdatedEvent.GetPayload();
                Console.WriteLine($"Book Updated: {book.Title} by {book.Author}, Published on {book.PublishedDate}");
            }
        }
    }
}
