using AutoMapper;
using DisneyWorld.Domain.Commands;
using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Application.Services
{
    public interface IPersonajesService
    {
        List<Personaje> GetAllCharacters();
        Personaje GetCharacterById(int id);
        Personaje GetCharacterByName(string nombre);
        void Update(Personaje personaje);
        void Delete(Personaje personaje);
        Personaje CreatePersonaje(PersonajeDtoForCreationOrUpdate personaje);
        List<PersonajeDtoForDetails> GetAllCharactersWithDetails();
        PersonajeDtoForDetails GetCharacteWithDetails(int id);
        List<Personaje> GetCharactersByAge(int age);
        List<Personaje> GetCharacterByMovieId(int movieId);
        List<Personaje> GetCharactersByWeight(int weight);
    }
    public class PersonajesService : IPersonajesService
    {
        private readonly ICharacteresRepository _repository;
        private readonly IMapper _mapper;

        public PersonajesService(ICharacteresRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Personaje CreatePersonaje(PersonajeDtoForCreationOrUpdate personaje)
        {
            var personajeMapeado = _mapper.Map<Personaje>(personaje);
            _repository.Add(personajeMapeado);
            

            return personajeMapeado;
        }

        public void Delete(Personaje personaje)
        {
            _repository.Delete(personaje);
        }

        public List<Personaje> GetAllCharacters()
        {
            return _repository.GetAllCharacters();
        }

        public List<PersonajeDtoForDetails> GetAllCharactersWithDetails()
        {
            return _repository.GetAllCharactersWithDetails();
        }

        public Personaje GetCharacterById(int id)
        {
            return _repository.GetCharacterById(id);
        }

        public Personaje GetCharacterByName(string nombre)
        {
            return _repository.GetCharacterByName(nombre);
        }

        public PersonajeDtoForDetails GetCharacteWithDetails(int id)
        {
            return _repository.GetCharacteWithDetails(id);
        }

        public List<Personaje> GetCharactersByAge(int age)
        {
            return _repository.GetCharactersByAge(age);
        }

        public void Update(Personaje personaje)
        {
            _repository.Update(personaje);
        }

        public List<Personaje> GetCharacterByMovieId(int movieId)
        {
           return _repository.GetCharacterByMovieId(movieId);
        }

        public List<Personaje> GetCharactersByWeight(int weight)
        {
            return _repository.GetCharactersByWeight(weight);
        }
    }
}
