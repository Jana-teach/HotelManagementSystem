using HotelManagementSystem.Dtos.DepartmentDto;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericRepo<Department> _repo;

        public DepartmentController(IGenericRepo<Department> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateDepartmentDto dto)
        {
            if (dto == null) return BadRequest("Dto is required");

            var dep = new Department()
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            await _repo.Add(dep);
            await _repo.Save();

            return Ok(dto);
        }
    }
}
