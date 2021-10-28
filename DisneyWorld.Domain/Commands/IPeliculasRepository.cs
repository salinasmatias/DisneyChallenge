using DisneyWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Commands
{
    public interface IPeliculasRepository
    {
        List<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        Pelicula GetPeliculaByTitle(string title);
        void Update(Pelicula pelicula);
        void Delete(Pelicula pelicula);
        void Add(Pelicula pelicula);
        List<Pelicula> GetPeliculasByCharacterId(int id);
    }
}
