using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos.GuestDto
{
    public class RoomForGuest
    {
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
