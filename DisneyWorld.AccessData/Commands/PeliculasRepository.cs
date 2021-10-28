using DisneyWorld.Domain.Commands;
using DisneyWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.AccessData.Commands
{
    public class PeliculasRepository : IPeliculasRepository
    {
        private readonly DisneyWorldContext _context;

        public PeliculasRepository(DisneyWorldContext context)
        {
            _context = context;
        }
        public void Add(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }

        public void Delete(Pelicula pelicula)
        {
            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }

        public List<Pelicula> GetPeliculasByCharacterId(int id)
        {

            var peliculasPorPersonaje = _context.PersonajePeliculas.Where(PeliculaPersonaje => PeliculaPersonaje.PersonajeId == id).ToList();

            List<Pelicula> peliculas = new List<Pelicula>();

            foreach (var item in peliculasPorPersonaje)
            {
                var pelicula = _context.Peliculas.Find(item.PeliculaId);
                peliculas.Add(pelicula);
            }

            return peliculas;
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _context.Peliculas.Find(id);
        }

        public Pelicula GetPeliculaByTitle(string title)
        {
            return _context.Peliculas.SingleOrDefault(Pelicula => Pelicula.Titulo == title);
        }

        public void Update(Pelicula pelicula)
        {
            _context.Update(pelicula);
            _context.SaveChanges();
        }
    }
}
