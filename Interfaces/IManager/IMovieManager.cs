using dto = Models.DTOs;
namespace Interfaces.IManager
{
    public interface IMovieManager
    {
        Task<IList<dto.Movie>> GetAllAsync(string? title, string? genre);
        Task<dto.Movie> GetByIdAsync(int id);
        Task AddAsync(dto.Movie movie);
        Task UpdateAsync(dto.Movie movie);
        Task DeleteAsync(int id);

    }
}
