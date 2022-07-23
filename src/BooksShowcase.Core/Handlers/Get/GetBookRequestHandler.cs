using BooksShowcase.Core.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksShowcase.Core.Handlers.Get;

public class GetBookRequestHandler: IRequestHandler<GetBookRequest, Book>
{
    private readonly IBooksReader _booksReader;
    private readonly ILogger<GetBookRequestHandler> _logger;

    public GetBookRequestHandler(IBooksReader booksReader, ILogger<GetBookRequestHandler> logger)
    {
        _booksReader = booksReader;
        _logger = logger;
    }
    
    public async Task<Book> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting books {@Request}", request);
        return await _booksReader.GetBookById(request.BookUuid);
    }
}