namespace BooksShowcase.Core.Exceptions;

public class NotFoundException: Exception
{
    private readonly string _entity;

    public NotFoundException(string entity)
    {
        _entity = entity;
    }
}