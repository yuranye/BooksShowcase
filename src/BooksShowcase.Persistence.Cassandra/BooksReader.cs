using BooksShowcase.Core;
using BooksShowcase.Core.Models;
using Cassandra.Mapping;

namespace BooksShowcase.Persistence.Cassandra;

public class BooksReader: IBooksReader
{
    private readonly IMapper _mapper;

    public BooksReader(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<PagedResponse<Book>> GetPages(int? pageNumber = null, int? pageSize = null, string? nameFilter = null)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookById(Guid requestBookUuid)
    {
        throw new NotImplementedException();
    }
}