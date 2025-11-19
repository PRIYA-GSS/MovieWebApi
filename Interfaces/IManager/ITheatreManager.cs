using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace Interfaces.IManager
{
    public interface ITheatreManager
    {
        Task<IList<dto.Theatre>> GetAllAsync();
        Task<dto.Theatre> GetByIdAsync(int id);
        Task<entity.Theatre> AddAsync(dto.Theatre theatre);
        Task UpdateAsync(dto.Theatre theatre);
        Task DeleteAsync(int id);
    }
}
