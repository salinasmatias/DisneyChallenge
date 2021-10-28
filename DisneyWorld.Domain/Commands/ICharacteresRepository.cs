using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Commands
{
    public interface ICharacteresRepository
    {
        List<Personaje> GetAllCharacters();
        Personaje GetCharacterById(int id);
        Personaje GetCharacterByName(string nombre);
        List<Personaje> GetCharacterByMovieId(int movieId);
        List<Personaje> GetCharactersByAge(int age);
        List<PersonajeDtoForDetails> GetAllCharactersWithDetails();
        List<Personaje> GetCharactersByWeight(int weight);
        PersonajeDtoForDetails GetCharacteWithDetails(int id);
        void Update(Personaje personaje);
        void Delete(Personaje personaje);
        void Add(Personaje personaje);
    }
}
