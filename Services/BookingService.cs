using Interfaces.IService;
using Interfaces.IManager;
using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace Services
{
    public class BookingService:IBookingService
    {
        private readonly IBookingManager _manager;
        public BookingService(IBookingManager manager)
        {
            _manager = manager;
        }
        public async Task<IList<dto.Booking>> GetAllAsync()
        {
            return await _manager.GetAllAsync();
        }
        public async Task<dto.Booking> GetByIdAsync(int id)
        {
            return await _manager.GetByIdAsync(id);

        }
        public async Task AddAsync(dto.Booking Booking)
        {
             await _manager.AddAsync(Booking);

        }

        public async Task UpdateAsync(dto.Booking Booking)
        {
            await _manager.UpdateAsync(Booking);
        }
        public async Task DeleteAsync(int id)
        {
            await _manager.DeleteAsync(id);
        }


    }
}
