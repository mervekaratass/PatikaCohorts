using Microsoft.AspNetCore.Mvc;
using Entities;
using Business.Abstracts;
using Business.Validators;

namespace MovieWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var movie = _movieService.GetById(id);
            if (movie == null)
                return NotFound(new { message = "Movie not found." });
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _movieService.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.MovieId }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Movie movie)
        {
            var validationResult = new MovieValidator().Validate(movie);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updatedMovie = _movieService.Update(id, movie);
            if (updatedMovie == null)
                return NotFound(new { message = "Movie not found." });

            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
         
            _movieService.Delete(id);
            return Ok("Başarıyla silindi");
        }

        [HttpGet("list")]
        public IActionResult GetMoviesByQuery([FromQuery] string? name, [FromQuery] string? category)
        {
            var movies = _movieService.GetByQuery(name, category);
            return Ok(movies);
        }
    }
}
