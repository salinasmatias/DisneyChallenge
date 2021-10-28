using AutoMapper;
using DisneyWorld.Domain.Commands;
using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System.Collections.Generic;

namespace DisneyWorld.Application.Services
{
    public interface IPeliculasService
    {
        List<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        Pelicula GetPeliculaByTitle(string title);
        PeliculaDtoForDetails GetMovieWithDetails(int id);
        void Update(Pelicula pelicula);
        void Delete(Pelicula pelicula);
        Pelicula CreatePelicula(PeliculaDtoForCreationOrUpdate pelicula);
        List<Pelicula> GetPeliculasByCharacterId(int id);
        List<Pelicula> GetPeliculasByOrder(string order);
        List<Pelicula> GetPeliculasByGenreId(int genre);
    }
    public class PeliculasService : IPeliculasService
    {
        private readonly IPeliculasRepository _repository;
        private readonly IMapper _mapper;

        public PeliculasService(IPeliculasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Pelicula CreatePelicula(PeliculaDtoForCreationOrUpdate pelicula)
        {
            var peliculaMapeada = _mapper.Map<Pelicula>(pelicula);
            _repository.Add(peliculaMapeada);

            return peliculaMapeada;
        }

        public void Delete(Pelicula pelicula)
        {
            _repository.Delete(pelicula);
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _repository.GetAllPeliculas();
        }

        public PeliculaDtoForDetails GetMovieWithDetails(int id)
        {
            return _repository.GetMovieWithDetails(id);
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _repository.GetPeliculaById(id);
        }

        public Pelicula GetPeliculaByTitle(string title)
        {
            return _repository.GetPeliculaByTitle(title);
        }

        public List<Pelicula> GetPeliculasByCharacterId(int id)
        {
            return _repository.GetPeliculasByCharacterId(id);
        }

        public List<Pelicula> GetPeliculasByGenreId(int genre)
        {
            return _repository.GetPeliculasByGenreId(genre);
        }

        public List<Pelicula> GetPeliculasByOrder(string order)
        {
            return order == "DESC" ? _repository.GetAllPeliculasSortedByDesc() : GetAllPeliculas();
        }

        public void Update(Pelicula pelicula)
        {
            _repository.Update(pelicula);
        }
    }
}
