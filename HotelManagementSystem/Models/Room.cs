using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    [Index(nameof(RoomNumber),IsUnique =true)]
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}
