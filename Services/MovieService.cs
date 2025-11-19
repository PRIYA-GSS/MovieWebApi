using Interfaces.IService;
using Interfaces.IManager;
using dto = Models.DTOs;
namespace Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieManager _manager;
        public MovieService(IMovieManager manager)
        {
            _manager = manager;
        }
        public async Task<IList<dto.Movie>> GetAllAsync(string? title, string? genre)
        {
            return await _manager.GetAllAsync(title, genre);
        }
        public async Task<dto.Movie> GetByIdAsync(int id)
        {
            return await _manager.GetByIdAsync(id);

        }
        public async Task AddAsync(dto.Movie movie)
        {
            await _manager.AddAsync(movie);
        }

        public async Task UpdateAsync(dto.Movie movie)
        {
            await _manager.UpdateAsync(movie);
        }
        public async Task DeleteAsync(int id)
        {
            await _manager.DeleteAsync(id);
        } 

    }
}
