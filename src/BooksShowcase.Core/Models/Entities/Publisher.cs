namespace BooksShowcase.Core.Models.Entities;

public class Publisher
{
    public Guid Uuid { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
}