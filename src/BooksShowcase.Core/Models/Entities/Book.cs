namespace BooksShowcase.Core.Models.Entities;

public class Book
{
    public Guid Uuid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }
    public long Pages { get; set; }
    public string Language { get; set; }
    public string EanUpc { get; set; }
    public BookType Type { get; set; }
    public float Price { get; set; }
    public Guid AuthorUuid { get; set; }
    public Guid PublisherUuid { get; set; }
}