namespace BooksShowcase.Core.Models;

public class PagedResponse<T>
{
    public string CurrentPageToken { get; set; }
    public string NextPageToken { get; set; }

    public IEnumerable<T> Data { get; set; }
}