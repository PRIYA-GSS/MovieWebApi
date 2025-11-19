using dto = Models.DTOs;

namespace Interfaces.IService
{
    public interface IUserService
    {
        Task<IList<dto.User>> GetAllAsync();
        Task<dto.User> GetByIdAsync(int id);
        Task AddAsync(dto.User User);
        Task UpdateAsync(dto.User User);
        Task DeleteAsync(int id);
    }
}
