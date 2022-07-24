using BooksShowcase.Core.Exceptions;
using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksShowcase.Core.Handlers.Update;

public class UpdateBookRequestHandler: IRequestHandler<UpdateBookRequest, Book>
{
    private readonly IBooksWriter _writer;
    private readonly IBooksReader _reader;
    private readonly ILogger<UpdateBookRequestHandler> _logger;

    public UpdateBookRequestHandler(IBooksWriter writer, IBooksReader reader, ILogger<UpdateBookRequestHandler> logger)
    {
        _writer = writer;
        _reader = reader;
        _logger = logger;
    }
    
    public async Task<Book> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var existingBook = await _reader.GetBookById(request.Uuid);

        if (existingBook == null)
        {
            throw new NotFoundException(request.Uuid.ToString());
        }
        
        return await _writer.UpdateBook(request);
    }
}