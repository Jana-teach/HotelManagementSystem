using HotelManagementSystem.Database;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repos.StaffRepo
{
    public class StaffRepo : GenericRepo<Staff>, IStaffRepo
    {
        public StaffRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Staff> GetStaffById(int id)
        {
            return await _context.Staff.Include(d=> d.Department).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
