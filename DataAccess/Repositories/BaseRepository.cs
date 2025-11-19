using DataAccess.Context;
using Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        
        public async Task<IList<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
           
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }
        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var movie= await dbSet.FindAsync(id);
            if (movie != null)
            {
                dbSet.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
