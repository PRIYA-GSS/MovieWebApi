using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interfaces.IService;
using dto = Models.DTOs;
namespace MovieWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? title, string? genre)
        {
            return Ok(await _service.GetAllAsync(title, genre));
        }
        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(dto.Movie movie)
        {
            await _service.AddAsync(movie);
            
            return CreatedAtRoute("GetMovieById", new { id = movie.Id }, movie);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] dto.Movie movie) { 

            if(id!=movie.Id) return BadRequest();
        
            await _service.UpdateAsync(movie);
            return Ok("Updated successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}
