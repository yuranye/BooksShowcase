using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using MediatR;

namespace BooksShowcase.Core.Handlers.Get;

public class GetBooksRequest: IRequest<PagedResponse<Book>>
{
    public string? NameFilter { get; set; }
    public int? PageSize { get; set; }
    
    public  string? PageToken { get; set; }
}