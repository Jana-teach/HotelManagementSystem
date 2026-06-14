using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos.GuestDto
{
    public class ReadGuestDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<string> staffs {  get; set; }
        public RoomForGuest Room {  get; set; }
    }
}
