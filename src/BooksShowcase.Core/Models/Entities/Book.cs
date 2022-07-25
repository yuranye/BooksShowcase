namespace BooksShowcase.Core.Models.Entities;

public class Book
{
    public Guid Uuid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }
    public int Pages { get; set; }
    public string Language { get; set; }
    public string EanUpc { get; set; }
    public int Type { get; set; }
    public float Price { get; set; }
    public IEnumerable<Author> Authors { get; set; }
    public IEnumerable<Publisher> Publishers { get; set; }
}