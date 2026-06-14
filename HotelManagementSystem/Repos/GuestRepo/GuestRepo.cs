using HotelManagementSystem.Database;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repos.GuestRepo
{
    public class GuestRepo : GenericRepo<Guest>, IGuestRepo
    {
        public GuestRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            return await _context.guests.Include(r=> r.Room).Include(s=> s.Staff)
                .ToListAsync();
        }

        public async Task<Guest> GetGuestById(int id)
        {
            var item = await _context.guests.Include(x=> x.Room)
                .Include(x=> x.Staff).FirstOrDefaultAsync(X=> X.Id ==  id);
            return item;
        }
    }
}
