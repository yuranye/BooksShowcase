using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;

namespace BooksShowcase.Api.Views;

public class BookView
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
    public IEnumerable<Author> Authors { get; set; }
    public IEnumerable<Publisher> Publishers { get; set; }
}