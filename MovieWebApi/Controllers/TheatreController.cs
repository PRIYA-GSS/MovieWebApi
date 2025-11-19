using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interfaces.IService;
using dto = Models.DTOs;

namespace MovieWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {

        private readonly ITheatreService _service;
        public TheatreController(ITheatreService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}", Name = "GetTheatreById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Theatre = await _service.GetByIdAsync(id);
            if (Theatre == null) return NotFound();
            return Ok(Theatre);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(dto.Theatre Theatre)
        {
            await _service.AddAsync(Theatre);

            return CreatedAtRoute("GetTheatreById", new { id =Theatre.TheatreId }, Theatre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] dto.Theatre Theatre)
        {

            if (id != Theatre.TheatreId) return BadRequest();

            await _service.UpdateAsync(Theatre);
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
