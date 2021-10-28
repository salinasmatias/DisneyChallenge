using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Entities
{
    public class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
