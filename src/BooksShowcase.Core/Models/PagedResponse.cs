namespace BooksShowcase.Core.Models;

public class PagedResponse<T>
{
    public int PageIndex { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    
    public IEnumerable<T> Data { get; set; }
}