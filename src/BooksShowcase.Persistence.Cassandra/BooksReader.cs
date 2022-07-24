using BooksShowcase.Core;
using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using BooksShowcase.Persistence.Cassandra.Options;
using Cassandra.Mapping;
using Microsoft.Extensions.Options;
using NETCore.Encrypt;

namespace BooksShowcase.Persistence.Cassandra;

public class BooksReader : IBooksReader
{
    public const int MaxPageSize = 1000;
    private readonly IMapper _mapper;
    private readonly IOptions<CassandraOptions> _options;

    public BooksReader(IMapper mapper, IOptions<CassandraOptions> options)
    {
        _mapper = mapper;
        _options = options;
    }

    public async Task<PagedResponse<Book>> GetPage(int? pageSize = null, string? pageToken = null, string? nameFilter = null)
    {
        byte[] decryptedPageToken = null!;
        if (pageToken != null)
        {
            decryptedPageToken =
                Convert.FromBase64String(EncryptProvider.AESDecrypt(pageToken, _options.Value.PageTokenEncryptionKey));
        }
        
        var cql = new Cql("SELECT * FROM books")
            .WithOptions(o =>
                o.SetPageSize(pageSize ?? MaxPageSize).SetPagingState(decryptedPageToken));

        if (nameFilter != null)
        {
            //TODO Implement filter provider
        }
        
        var page = await _mapper.FetchPageAsync<Book>(cql);

        return new PagedResponse<Book>
        {
            Data = page,
            CurrentPageToken = page.CurrentPagingState != null
                ? EncryptProvider.AESEncrypt(Convert.ToBase64String(page.CurrentPagingState), _options.Value.PageTokenEncryptionKey)
                : "",
            NextPageToken = page.PagingState != null
                ? EncryptProvider.AESEncrypt(Convert.ToBase64String(page.PagingState), _options.Value.PageTokenEncryptionKey)
                : "",
        };
    }

    public async Task<Book> GetBookById(Guid bookUuid) =>
        await _mapper.FirstOrDefaultAsync<Book>("SELECT * FROM books WHERE uuid = ?", bookUuid);
}