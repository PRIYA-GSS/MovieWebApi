using AutoMapper;
using Interfaces.IManager;
using Interfaces.IRepository;
using dto = Models.DTOs;
using entity = DataAccess.Entities;

namespace Managers
{
    public class TheatreManager:ITheatreManager
    {
        private readonly IBaseRepository<entity.Theatre> _repo;
        private readonly IMapper _mapper;
        public TheatreManager(IBaseRepository<entity.Theatre> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IList<dto.Theatre>> GetAllAsync()
        {
            var Theatres = await _repo.GetAllAsync();

            return _mapper.Map<IList<dto.Theatre>>(Theatres);
        }
        public async Task<dto.Theatre> GetByIdAsync(int id)
        {
            var Theatre = await _repo.GetByIdAsync(id);
            if (Theatre == null)
                throw new Exception("Theatre not found");

            return _mapper.Map<dto.Theatre>(Theatre);
        }
        public async Task AddAsync(dto.Theatre Theatre)
        {
            var newTheatre = _mapper.Map<entity.Theatre>(Theatre);
            _mapper.Map(Theatre, newTheatre);
            await _repo.AddAsync(newTheatre);
           
        }
        public async Task UpdateAsync(dto.Theatre Theatre)
        {
            var entityTheatre = _mapper.Map<entity.Theatre>(Theatre);
            var newTheatre = await _repo.GetByIdAsync(entityTheatre.TheatreId);
            if (newTheatre == null) throw new Exception("Invalid id");

            await _repo.UpdateAsync(entityTheatre);
        }
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
