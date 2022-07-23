using BooksShowcase.Core.Models;
using MediatR;

namespace BooksShowcase.Core.Handlers.Get;

public class GetBookRequest: IRequest<Book>
{
    public Guid BookUuid { get; set; }   
}