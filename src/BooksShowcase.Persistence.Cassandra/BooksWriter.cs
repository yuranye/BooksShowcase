using BooksShowcase.Core;
using BooksShowcase.Core.Handlers.Create;
using BooksShowcase.Core.Handlers.Update;
using BooksShowcase.Core.Models;
using BooksShowcase.Core.Models.Entities;
using Cassandra.Mapping;

namespace BooksShowcase.Persistence.Cassandra;

public class BooksWriter: IBooksWriter
{
    private readonly IMapper _mapper;

    public BooksWriter(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<Book> CreateBook(CreateBookRequest request)
    {
        var newBook = new Book
        {
            Name = request.Name,
            Uuid = Guid.NewGuid(), //TODO Add snowflake uuid generation
        };
        
        await _mapper.InsertAsync(newBook);

        return newBook;
    }

    public async Task DeleteBook(Guid bookUuid) =>
        await _mapper.DeleteAsync(new Book { Uuid = bookUuid });

    public async Task<Book> UpdateBook(UpdateBookRequest request)
    {
        var newBook = new Book
        {
            Name = request.Name,
            Uuid = request.Uuid,
        };
        
        await _mapper.UpdateAsync(newBook);

        return newBook;
    }
}