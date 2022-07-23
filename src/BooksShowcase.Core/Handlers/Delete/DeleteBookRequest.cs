using MediatR;

namespace BooksShowcase.Core.Handlers.Delete;

public class DeleteBookRequest: IRequest
{
    public Guid BookUuid { get; set; }
}