using Interfaces.IService;
using Interfaces.IManager;
using dto = Models.DTOs;
using entity = DataAccess.Entities;

namespace Services
{
   public class TheatreService:ITheatreService
    {
        private readonly ITheatreManager _manager;
        public TheatreService(ITheatreManager manager)
        {
            _manager = manager;
        }
        public async Task<IList<dto.Theatre>> GetAllAsync()
        {
            return await _manager.GetAllAsync();
        }
        public async Task<dto.Theatre> GetByIdAsync(int id)
        {
            return await _manager.GetByIdAsync(id);

        }
        public async Task AddAsync(dto.Theatre Theatre)
        {
            await _manager.AddAsync(Theatre);

        }

        public async Task UpdateAsync(dto.Theatre Theatre)
        {
            await _manager.UpdateAsync(Theatre);
        }
        public async Task DeleteAsync(int id)
        {
            await _manager.DeleteAsync(id);
        }

    }
}
