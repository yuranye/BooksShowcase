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

    public async Task<PagedResponse<Book>> GetPages(int? pageNumber = null, int? pageSize = null, string? nameFilter = null)
    {
        //TODO Add pagination and search
        var books = (await _mapper.FetchAsync<Book>("SELECT * FROM books")).ToList();
        return new PagedResponse<Book>
        {
            Data = books,
            PageIndex = 1,
            TotalPages = 1,
            TotalRecords = books.Count,
        };
    }

    public async Task<Book> GetBookById(Guid bookUuid) =>
        await _mapper.FirstOrDefaultAsync<Book>("SELECT * FROM books WHERE uuid = ?", bookUuid);
}