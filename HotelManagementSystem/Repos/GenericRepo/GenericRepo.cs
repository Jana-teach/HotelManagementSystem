
using HotelManagementSystem.Database;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repos.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
             _context.Set<T>().Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             _context.Set<T>().Update(entity);
        }
    }
}
