using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos.DepartmentDto
{
    public class CreateDepartmentDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
