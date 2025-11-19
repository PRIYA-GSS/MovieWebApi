using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interfaces.IService;
using dto = Models.DTOs;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var User = await _service.GetByIdAsync(id);
            if (User == null) return NotFound();
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(dto.User User)
        {
             await _service.AddAsync(User);

            return CreatedAtRoute("GetUserById", new { id = User.Id }, User);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] dto.User User)
        {

            if (id != User.Id) return BadRequest();

            await _service.UpdateAsync(User);
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
