namespace DisneyWorld.Domain.Entities
{
    public class PersonajePelicula
    {
        public int PersonajeId { get; set; }
        public int PeliculaId { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Personaje Personaje { get; set; }
    }
}
