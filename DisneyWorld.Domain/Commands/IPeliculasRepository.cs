using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System.Collections.Generic;

namespace DisneyWorld.Domain.Commands
{
    public interface IPeliculasRepository
    {
        List<Pelicula> GetAllPeliculas();
        List<Pelicula> GetAllPeliculasSortedByDesc();
        Pelicula GetPeliculaById(int id);
        PeliculaDtoForDetails GetMovieWithDetails(int id);
        Pelicula GetPeliculaByTitle(string title);
        void Update(Pelicula pelicula);
        void Delete(Pelicula pelicula);
        void Add(Pelicula pelicula);
        List<Pelicula> GetPeliculasByCharacterId(int id);
        List<Pelicula> GetPeliculasByGenreId(int genre);
    }
}
