using BooksShowcase.Core.Models;
using MediatR;

namespace BooksShowcase.Core.Handlers.Update;

public class UpdateBookRequest: IRequest<Book>
{
    public Guid BookUuid { get; set; }
    public string Name { get; set; }
}