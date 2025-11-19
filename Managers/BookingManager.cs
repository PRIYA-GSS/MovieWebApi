using AutoMapper;
using Interfaces.IRepository;
using entity= DataAccess.Entities;
using dto = Models.DTOs;
namespace Managers
{
    public class BookingManager
    {
        private readonly IBaseRepository<entity.Booking> _repo;
        private readonly IMapper _mapper;
        public BookingManager(IBaseRepository<entity.Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IList<dto.Booking>> GetAllAsync()
        {
            var Bookings = await _repo.GetAllAsync();

            return _mapper.Map<IList<dto.Booking>>(Bookings);
        }
        public async Task<dto.Booking> GetByIdAsync(int id)
        {
            var Booking = await _repo.GetByIdAsync(id);
            if (Booking == null)
                throw new Exception("Booking not found");

            return _mapper.Map<dto.Booking>(Booking);
        }
        public async Task<entity.Booking> AddAsync(dto.Booking Booking)
        {
            var newBooking = _mapper.Map<entity.Booking>(Booking);
            _mapper.Map(Booking, newBooking);
            await _repo.AddAsync(newBooking);
            return newBooking;
        }
        public async Task UpdateAsync(dto.Booking Booking)
        {
            var entityBooking = _mapper.Map<entity.Booking>(Booking);
            var newBooking = await _repo.GetByIdAsync(entityBooking.BookingId);
            if (newBooking == null) throw new Exception("Invalid id");

            await _repo.UpdateAsync(entityBooking);
        }
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

    }
}

