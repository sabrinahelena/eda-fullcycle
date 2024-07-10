namespace Library.Entities;

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

    public void SetTitle(string title)
    {
        this.Title = title;
    }

    public void SetAuthor(string author)
    {
        this.Author = author;
    }

    public void SetPublishedDate(DateTime publishedDate)
    {
        this.PublishedDate = publishedDate;
    }
}

