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
            CreateMap<LibraryBookDTo, LibraryBook>();
            CreateMap<LibraryBook, LibraryBookDTo>();

            CreateMap<TitleDTO, Title>();
            CreateMap<Title, TitleDTO>();

            CreateMap<Images, ImagesDTO>().ReverseMap();

            CreateMap<SectionDTO, Section>();
            CreateMap<Section, SectionDTO>();
        }
    }
}
