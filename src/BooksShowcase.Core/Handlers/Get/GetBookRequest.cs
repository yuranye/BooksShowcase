using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using MediatR;

namespace BooksShowcase.Core.Handlers.Get;

public class GetBookRequest: IRequest<Book>
{
    public Guid Uuid { get; set; }
}