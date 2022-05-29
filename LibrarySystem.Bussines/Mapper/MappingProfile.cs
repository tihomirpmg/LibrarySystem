using AutoMapper;
using DataAcess.Data.Models;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;

namespace LibrarySystem.Bussines.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryBookDto, LibraryBook>();
            CreateMap<LibraryBook, LibraryBookDto>();

            CreateMap<TitleDto, Title>();
            CreateMap<Title, TitleDto>();

            CreateMap<Images, ImageDto>().ReverseMap();

            CreateMap<SectionDto, Section>();
            CreateMap<Section, SectionDto>();
        }
    }
}
