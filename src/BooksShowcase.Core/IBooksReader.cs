using BooksShowcase.Core.Models;

namespace BooksShowcase.Core;

public interface IBooksReader
{
    Task<PagedResponse<Book>> GetPages(int? pageNumber = null, int? pageSize = null, string? nameFilter = null);
    Task<Book> GetBookById(Guid bookUuid);
}