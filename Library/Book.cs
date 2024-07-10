namespace Library;

public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public DateTime PublishedDate { get; private set; }

    public Book(string title, string author, DateTime publishedDate)
    {
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
    }
}

