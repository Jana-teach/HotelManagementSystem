using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos.StaffDto
{
    public class CreateStaffDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
