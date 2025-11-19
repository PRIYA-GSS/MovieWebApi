using dto = Models.DTOs;

namespace Interfaces.IService
{
    public interface ITheatreService
    {
        Task<IList<dto.Theatre>> GetAllAsync();
        Task<dto.Theatre> GetByIdAsync(int id);
        Task AddAsync(dto.Theatre Theatre);
        Task UpdateAsync(dto.Theatre Theatre);
        Task DeleteAsync(int id);
    }
}
