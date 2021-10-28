using System.Collections.Generic;

namespace DisneyWorld.Domain.Entities
{
    public class Personaje
    {
        public Personaje()
        {
            PersonajePeliculas = new HashSet<PersonajePelicula>();
        }
        public int PersonajeId { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
        public string Historia { get; set; }

        public ICollection<PersonajePelicula> PersonajePeliculas { get; set; }
    }
}
