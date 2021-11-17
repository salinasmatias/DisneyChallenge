using AutoMapper;
using DisneyWorld.Application.Services;
using DisneyWorld.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DisneyWorld.Presentation.Controllers
{
    [Route("movies")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class MoviesController : ControllerBase
    {
        private readonly IPeliculasService _service;
        private readonly IMapper _mapper;

        public MoviesController(IPeliculasService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllMovies(string name = null, int? genre = null, string order = null)
        {
            try
            {
                if(name != null && genre == null && order == null) 
                {
                    var pelicula = _service.GetPeliculaByTitle(name);
                    var peliculaMapeada = _mapper.Map<PeliculaDto>(pelicula);

                    return Ok(peliculaMapeada);
                }

                else if(name == null && genre != null && order == null) 
                {
                    var peliculas = _service.GetPeliculasByGenreId(genre.Value);
                    var peliculasMapeadas = _mapper.Map<List<PeliculaDto>>(peliculas);

                    return Ok(peliculasMapeadas);
                }

                else if(name == null && genre == null && order != null)
                {
                    var peliculas = _service.GetPeliculasByOrder(order);
                    var peliculasMapeadas = _mapper.Map<List<PeliculaDto>>(peliculas);

                    return Ok(peliculasMapeadas);
                }

                else
                {
                    var peliculas = _service.GetAllPeliculas();
                    var peliculasMapeadas = _mapper.Map<List<PeliculaDto>>(peliculas);

                    return Ok(peliculasMapeadas);
                }
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(PeliculaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateMovie([FromBody] PeliculaDtoForCreationOrUpdate pelicula)
        {
            try
            {
                var peliculaEntity = _service.CreatePelicula(pelicula);

                if (peliculaEntity != null)
                {
                    var peliculaCreada = _mapper.Map<PeliculaDto>(peliculaEntity);
                    return Created("~movies/", peliculaCreada);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                var movie = _service.GetPeliculaById(id);

                if (movie == null)
                {
                    return NotFound();
                }

                _service.Delete(movie);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateMovie(int id, [FromBody] PeliculaDtoForCreationOrUpdate movie)
        {
            try
            {
                if (movie == null)
                {
                    return BadRequest("Todos los campos deben estar completos para poder realizar la actualización de este elemento.");
                }

                var peliculaEntity = _service.GetPeliculaById(id);

                if (peliculaEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(movie, peliculaEntity);
                _service.Update(peliculaEntity);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{id}/details")]
        [ProducesResponseType(typeof(PeliculaDtoForDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetMovieWithDetails(int id)
        {
            try
            {
                var movie = _service.GetMovieWithDetails(id);

                return Ok(movie);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
