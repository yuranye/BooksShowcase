using BooksShowcase.Core.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksShowcase.Core.Handlers.Get;

public class GetBooksRequestHandler: IRequestHandler<GetBooksRequest, PagedResponse<Book>>
{
    private readonly IBooksReader _booksReader;
    private readonly ILogger<GetBooksRequestHandler> _logger;

    public GetBooksRequestHandler(IBooksReader booksReader, ILogger<GetBooksRequestHandler> logger)
    {
        _booksReader = booksReader;
        _logger = logger;
    }
    
    public async Task<PagedResponse<Book>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting books {@Request}", request);
        return await _booksReader.GetPage(request.PageSize, request.PageToken, request.NameFilter);
    }
}