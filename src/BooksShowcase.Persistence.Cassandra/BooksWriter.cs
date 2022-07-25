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
    private readonly AutoMapper.IMapper _autoMapper;

    public BooksWriter(IMapper mapper, AutoMapper.IMapper autoMapper)
    {
        _mapper = mapper;
        _autoMapper = autoMapper;
    }
    
    public async Task<Book> CreateBook(CreateBookRequest request)
    {
        var newBook = _autoMapper.Map<Book>(request);
        
        newBook.Uuid = Guid.NewGuid(); //TODO Add snowflake uuid generation
        
        await _mapper.InsertAsync(newBook);

        return newBook;
    }

    public async Task DeleteBook(Guid bookUuid) =>
        await _mapper.DeleteAsync(new Book { Uuid = bookUuid });

    public async Task<Book> UpdateBook(UpdateBookRequest request)
    {
        var book = _autoMapper.Map<Book>(request);

        await _mapper.UpdateAsync(book);

        return book;
    }
}