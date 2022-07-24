using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using MediatR;

namespace BooksShowcase.Core.Handlers.Update;

public class UpdateBookRequest: IRequest<Book>
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