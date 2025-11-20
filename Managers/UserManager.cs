using AutoMapper;
using Interfaces.IManager;
using Interfaces.IRepository;
using dto = Models.DTOs;
using entity = DataAccess.Entities;

namespace Managers
{
    public class UserManager:IUserManager
    {
        private readonly IBaseRepository<entity.User> _repo;
        private readonly IMapper _mapper;
        public UserManager(IBaseRepository<entity.User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IList<dto.User>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
          
            return _mapper.Map<IList<dto.User>>(users);
        }
        public async Task<dto.User> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            return _mapper.Map<dto.User>(user);
        }
        public async Task AddAsync(dto.User user)
        {
            var newuser = _mapper.Map<entity.User>(user);
            _mapper.Map(user, newuser);
            await _repo.AddAsync(newuser);
     
        }
        public async Task UpdateAsync(dto.User user)
        {
            var entityUser = _mapper.Map<entity.User>(user);
            var newUser = await _repo.GetByIdAsync(entityUser.UserId);
            if (newUser == null) throw new Exception("Invalid id");

            await _repo.UpdateAsync(entityUser);
        }
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

    }
}
