﻿namespace DisneyWorld.Domain.Dtos
{
    public class PersonajeDtoForCreationOrUpdate
    {
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
        public string Historia { get; set; }
    }
}
