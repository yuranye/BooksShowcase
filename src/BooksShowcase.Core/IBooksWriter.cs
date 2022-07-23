using BooksShowcase.Core.Handlers.Create;
using BooksShowcase.Core.Handlers.Update;
using BooksShowcase.Core.Models;

namespace BooksShowcase.Core;

public interface IBooksWriter
{
    Task<Book> CreateBook(CreateBookRequest request);
    Task DeleteBook(Guid bookUuid);
    Task<Book> UpdateBook(UpdateBookRequest request);
}