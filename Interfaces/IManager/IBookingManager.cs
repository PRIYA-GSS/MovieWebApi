using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace Interfaces.IManager
{
    public interface IBookingManager
    {
        Task<IList<dto.Booking>> GetAllAsync();
        Task<dto.Booking> GetByIdAsync(int id);
        Task<entity.Booking> AddAsync(dto.Booking booking);
        Task UpdateAsync(dto.Booking booking);
        Task DeleteAsync(int id);
    }
}
