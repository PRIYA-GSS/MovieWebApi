using dto = Models.DTOs;
namespace Interfaces.IService
{
    public interface IMovieService
    {
        Task<IList<dto.Movie>> GetAllAsync(string? title, string? genre);
        Task<dto.Movie> GetByIdAsync(int id);
        Task AddAsync(dto.Movie movie);
        Task UpdateAsync(dto.Movie movie);
        Task DeleteAsync(int id);

    }
}
