using AutoMapper;
using BooksShowcase.Core.Handlers.Create;
using BooksShowcase.Core.Handlers.Update;
using BooksShowcase.Core.Models.Entities;

namespace BooksShowcase.Persistence.Cassandra.Automapper;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CreateBookRequest, Book>()
            .ForMember(book => book.Type,
                opt => opt.MapFrom(r => r.Type));
        
        CreateMap<UpdateBookRequest, Book>()
            .ForMember(book => book.Type,
                opt => opt.MapFrom(r => r.Type));
    }
}