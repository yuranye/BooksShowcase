using BooksShowcase.Core.Exceptions;
using BooksShowcase.Core.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksShowcase.Core.Handlers.Create;

public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Book>
{
    private readonly IBooksWriter _writer;
    private readonly IBooksReader _reader;
    private readonly ILogger<CreateBookRequestHandler> _logger;

    public CreateBookRequestHandler(IBooksWriter writer, IBooksReader reader, ILogger<CreateBookRequestHandler> logger)
    {
        _writer = writer;
        _reader = reader;
        _logger = logger;
    }

    public async Task<Book> Handle(CreateBookRequest request, CancellationToken cancellationToken)
    {
        //TODO Add validation for conflicts, define duplicate criteria

        return await _writer.CreateBook(request);
    }
}