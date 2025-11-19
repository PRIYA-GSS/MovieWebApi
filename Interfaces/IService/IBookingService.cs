using dto = Models.DTOs;

namespace Interfaces.IService
{
    public interface IBookingService
    {
        Task<IList<dto.Booking>> GetAllAsync();
        Task<dto.Booking> GetByIdAsync(int id);
        Task AddAsync(dto.Booking Booking);
        Task UpdateAsync(dto.Booking Booking);
        Task DeleteAsync(int id);
    }
}
