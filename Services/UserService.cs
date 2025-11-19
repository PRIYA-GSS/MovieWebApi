using Interfaces.IManager;
using Interfaces.IService;
using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserManager _manager;
        public UserService(IUserManager manager)
        {
            _manager = manager;
        }
        public async Task<IList<dto.User>> GetAllAsync()
        {
            return await _manager.GetAllAsync();
        }
        public async Task<dto.User> GetByIdAsync(int id)
        {
            return await _manager.GetByIdAsync(id);

        }
        public async Task AddAsync(dto.User User)
        {
           await _manager.AddAsync(User);

        }

        public async Task UpdateAsync(dto.User User)
        {
            await _manager.UpdateAsync(User);
        }
        public async Task DeleteAsync(int id)
        {
            await _manager.DeleteAsync(id);
        }

    }
}
