using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using MediatR;

namespace BooksShowcase.Core.Handlers.Create;

public class CreateBookRequest: IRequest<Book>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }
    public int Pages { get; set; }
    public string Language { get; set; }
    public string EanUpc { get; set; }
    public BookType Type { get; set; }
    public float Price { get; set; }
    public IEnumerable<Author> Authors { get; set; }
    public IEnumerable<Publisher> Publishers { get; set; }
}