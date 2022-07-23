using BooksShowcase.Core.Models;
using MediatR;

namespace BooksShowcase.Core.Handlers.Create;

public class CreateBookRequest: IRequest<Book>
{
    public string Name { get; set; }
}