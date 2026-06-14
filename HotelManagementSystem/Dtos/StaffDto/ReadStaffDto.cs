using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos.StaffDto
{
    public class ReadStaffDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? phone { get; set; }
        public string Department { get; set; }
    }
}
