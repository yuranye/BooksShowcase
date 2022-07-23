using BooksShowcase.Core.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksShowcase.Core.Handlers.Delete;

public class DeleteBookRequestHandler: IRequestHandler<DeleteBookRequest>
{
    private readonly IBooksReader _reader;
    private readonly IBooksWriter _writer;
    private readonly ILogger<DeleteBookRequestHandler> _logger;

    public DeleteBookRequestHandler(IBooksReader reader, IBooksWriter writer, ILogger<DeleteBookRequestHandler> logger)
    {
        _reader = reader;
        _writer = writer;
        _logger = logger;
    }
    
    public async Task<Unit> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var existingBook = await _reader.GetBookById(request.BookUuid);

        if (existingBook == null)
        {
            throw new NotFoundException(request.BookUuid.ToString());
        }

        await _writer.DeleteBook(request.BookUuid);
        
        return Unit.Value;
    }
}