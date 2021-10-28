using AutoMapper;
using DisneyWorld.Domain.Commands;
using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DisneyWorld.AccessData.Commands
{
    public class CharactersRepository : ICharacteresRepository
    {
        private readonly DisneyWorldContext _context;
        private readonly IMapper _mapper;
        private readonly IPeliculasRepository _peliculasRepository;

        public CharactersRepository(DisneyWorldContext context, IMapper mapper, IPeliculasRepository peliculasRepository)
        {
            _context = context;
            _mapper = mapper;
            _peliculasRepository = peliculasRepository;
        }

        public void Add(Personaje personaje)
        {
            _context.Personajes.Add(personaje);
            _context.SaveChanges();
        }

        public void Delete(Personaje personaje)
        {
            _context.Personajes.Remove(personaje);
            _context.SaveChanges();
        }

        public List<Personaje> GetAllCharacters()
        {
            return _context.Personajes.ToList();
        }

        public List<PersonajeDtoForDetails> GetAllCharactersWithDetails()
        {
            var personajes = GetAllCharacters();
            var personajesConDetalles = new List<PersonajeDtoForDetails>();

            foreach (var personaje in personajes)
            {
                var personajeMapeado = _mapper.Map<PersonajeDtoForDetails>(personaje);
                var peliculasMapeadas = _mapper.Map<List<PeliculaDto>>(_peliculasRepository.GetPeliculasByCharacterId(personaje.PersonajeId));
                personajeMapeado.peliculas = peliculasMapeadas;
                personajesConDetalles.Add(personajeMapeado);
            }

            return personajesConDetalles;
        }

        public PersonajeDtoForDetails GetCharacteWithDetails(int id)
        {
            var personaje = GetCharacterById(id);
            var personajeConDetalles = _mapper.Map<PersonajeDtoForDetails>(personaje);
            var peliculasMapeadas = _mapper.Map<List<PeliculaDto>>(_peliculasRepository.GetPeliculasByCharacterId(personaje.PersonajeId));
            personajeConDetalles.peliculas = peliculasMapeadas;

            return personajeConDetalles;
        }

        public Personaje GetCharacterById(int id)
        {
            return _context.Personajes.Find(id);
        }

        public Personaje GetCharacterByName(string nombre)
        {
            return _context.Personajes.SingleOrDefault(Personaje => Personaje.Nombre == nombre);
        }

        public void Update(Personaje personaje)
        {
            _context.Update(personaje);
            _context.SaveChanges();
        }

        public List<Personaje> GetCharactersByAge(int age)
        {
            return _context.Personajes.Where(Personaje => Personaje.Edad == age).ToList();
        }

        public List<Personaje> GetCharacterByMovieId(int movieId)
        {
            var personajePeliculas = _context.PersonajePeliculas.Where(PersonajePeliculas => PersonajePeliculas.PeliculaId == movieId);
            List<Personaje> personajes = new List<Personaje>();

            foreach (var pelicula in personajePeliculas)
            {
                var personaje = _context.Personajes.Find(pelicula.PersonajeId);
                personajes.Add(personaje);
            }

            return personajes;
        }

        public List<Personaje> GetCharactersByWeight(int weight)
        {
            return _context.Personajes.Where(Personaje => Personaje.Peso == weight).ToList();
        }
    }
}
