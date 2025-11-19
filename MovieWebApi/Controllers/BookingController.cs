using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interfaces.IService;
using dto = Models.DTOs;


namespace MovieWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookingController(IBookingService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}", Name = "GetBookingById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Booking = await _service.GetByIdAsync(id);
            if (Booking == null) return NotFound();
            return Ok(Booking);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(dto.Booking Booking)
        {
            await _service.AddAsync(Booking);

            return CreatedAtRoute("GetBookingById", new { id = Booking.BookingId }, Booking);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] dto.Booking Booking)
        {

            if (id != Booking.BookingId) return BadRequest();

            await _service.UpdateAsync(Booking);
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
