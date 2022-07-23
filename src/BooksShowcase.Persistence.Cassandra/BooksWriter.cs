using BooksShowcase.Core;
using BooksShowcase.Core.Models;

namespace BooksShowcase.Persistence.Cassandra;

public class BooksWriter: IBooksReader
{
    public Task<PagedResponse<Book>> GetPages(int? pageNumber = null, int? pageSize = null, string? nameFilter = null)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookById(Guid requestBookUuid)
    {
        throw new NotImplementedException();
    }
}