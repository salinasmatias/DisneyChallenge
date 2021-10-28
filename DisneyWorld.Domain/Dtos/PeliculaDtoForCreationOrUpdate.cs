namespace DisneyWorld.Domain.Dtos
{
    public class PeliculaDtoForCreationOrUpdate
    {
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public string FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public int GeneroId { get; set; }
    }
}
