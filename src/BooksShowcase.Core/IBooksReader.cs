using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;

namespace BooksShowcase.Core;

public interface IBooksReader
{
    Task<PagedResponse<Book>> GetPage(int? pageSize = null, string? pageToken = null, string? nameFilter = null);
    Task<Book> GetBookById(Guid bookUuid);
}