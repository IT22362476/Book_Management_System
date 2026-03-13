using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();

        CreateMap<CreateBookDto, Book>();

        CreateMap<UpdateBookDto, Book>();
    }
}