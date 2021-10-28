using AutoMapper;
using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyWorld.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personaje, PersonajeDto>();
            CreateMap<PersonajeDtoForCreationOrUpdate, Personaje>();
            CreateMap<Pelicula, PeliculaDto>();
            CreateMap<Personaje, PersonajeDtoForDetails>();
        }
    }
}
