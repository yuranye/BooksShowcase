using BooksShowcase.Core.Exceptions;
using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksShowcase.Core.Handlers.Get;

public class GetBookRequestHandler : IRequestHandler<GetBookRequest, Book>
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
        var book = await _booksReader.GetBookById(request.Uuid);

        if (book == null)
        {
            throw new NotFoundException(request.Uuid.ToString());
        }
        
        return book;
    }
}