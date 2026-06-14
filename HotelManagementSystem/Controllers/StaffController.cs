using HotelManagementSystem.Dtos.StaffDto;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;
using HotelManagementSystem.Repos.StaffRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepo _repo;
        private readonly IGenericRepo<Department> _deprepo;

        public StaffController(IStaffRepo repo, IGenericRepo<Department> deprepo)
        {
            _deprepo = deprepo;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStaffDto dto)
        {
            if (dto == null) return BadRequest("Dto is required");
            var dep = await _deprepo.GetById(dto.DepartmentId);
            if (dep == null) return NotFound("Department not Found");

            var staff = new Staff()
            {
                Name = dto.Name,
                Email = dto.Email,
                phone = dto.phone,
                DepartmentId = dto.DepartmentId
            };

            await _repo.Add(staff);
            await _repo.Save();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var staff = await _repo.GetStaffById(id);
            if (staff == null) return NotFound();

            var dto = new ReadStaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Email = staff.Email,
                phone = staff.phone,
                Department = staff.Department!=null?staff.Department.Name:null
            };

            return Ok(dto);
        }
    }
}
