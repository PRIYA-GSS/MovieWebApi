using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace Interfaces.IManager
{
    public interface IUserManager
    {
        Task<IList<dto.User>> GetAllAsync();
        Task<dto.User> GetByIdAsync(int id);
        Task<entity.User> AddAsync(dto.User user);
        Task UpdateAsync(dto.User user);
        Task DeleteAsync(int id);

    }
}
