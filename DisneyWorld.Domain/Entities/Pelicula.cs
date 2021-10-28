using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Entities
{
    public class Pelicula
    {
        public Pelicula()
        {
            PersonajePeliculas = new HashSet<PersonajePelicula>();
        }
        public int PeliculaId { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public int GeneroId { get; set; }

        public Genero Genero { get; set; }
        public ICollection<PersonajePelicula> PersonajePeliculas { get; set; }
    }
}
