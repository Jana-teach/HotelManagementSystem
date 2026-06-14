using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;

namespace HotelManagementSystem.Repos.StaffRepo
{
    public interface IStaffRepo : IGenericRepo<Staff>
    {
        public Task<Staff> GetStaffById(int id);
    }
}
