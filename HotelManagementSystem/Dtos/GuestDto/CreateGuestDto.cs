using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos.GuestDto
{
    public class CreateGuestDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<int>? Staff { get; set; }
        public RoomForGuest? Room {  get; set; }
    }
}
