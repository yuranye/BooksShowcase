using AutoMapper;
using BooksShowcase.Api.Views;
using BooksShowcase.Core.Models.Entities;

namespace BooksShowcase.Api.Mappings;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<Book, BookView>();
    }
}