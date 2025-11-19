using Interfaces.IManager;
using Interfaces.IRepository;
using entity = DataAccess.Entities;
using dto = Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Managers
{
  public class MovieManager: IMovieManager
    {
        private readonly IBaseRepository<entity.Movie> _repo;
        private readonly IMapper _mapper;
        public MovieManager(IBaseRepository<entity.Movie> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IList<dto.Movie>> GetAllAsync(string? title,string? genre)
        {
            var movies = await _repo.GetAllAsync();
            var filtered= movies.Where(a => a.Title.ToLower().Contains(title?.ToLower())||a.Genre.ToLower().Contains(genre?.ToLower())) ;
            return _mapper.Map<IList<dto.Movie>>(filtered); 
        }
        public async Task<dto.Movie> GetByIdAsync(int id)
        {
            var movie= await _repo.GetByIdAsync(id);
            if (movie == null)
                throw new Exception("Movie not found");
          
            return _mapper.Map<dto.Movie>(movie);
        }
        public async Task AddAsync(dto.Movie movie)
        {
            var newmovie=_mapper.Map<entity.Movie>(movie);
            _mapper.Map(movie, newmovie);
            await _repo.AddAsync(newmovie);

        }
        public async Task UpdateAsync(dto.Movie movie)
        {
            var entityMovie = _mapper.Map<entity.Movie>(movie);
            var newmovie = await _repo.GetByIdAsync(entityMovie.Id);
            if (newmovie == null) throw new Exception("Invalid id");

            await _repo.UpdateAsync(entityMovie);
        }
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
        
    }
}
