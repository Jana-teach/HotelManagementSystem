using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;

namespace HotelManagementSystem.Repos.GuestRepo
{
    public interface IGuestRepo:IGenericRepo<Guest>
    {
        public Task<IEnumerable<Guest>> GetAllGuests();
        public Task<Guest> GetGuestById(int id);
    }
}
