using AutoMapper;
using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;

namespace DisneyWorld.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personaje, PersonajeDto>();
            CreateMap<PersonajeDtoForCreationOrUpdate, Personaje>();
            CreateMap<Pelicula, PeliculaDto>()
                                              .ForMember(PeliculaDto => PeliculaDto.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<Personaje, PersonajeDtoForDetails>();
            CreateMap<PeliculaDtoForCreationOrUpdate, Pelicula>();
            CreateMap<Pelicula, PeliculaDtoForDetails>()
                                                        .ForMember(PeliculaDtoForDetails => PeliculaDtoForDetails.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion.ToString("yyyy-MM-dd"))); ;
        }
    }
}
