using HotelManagementSystem.Dtos.GuestDto;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repos.GenericRepo;
using HotelManagementSystem.Repos.GuestRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepo _repo;
        private readonly IGenericRepo<Staff> _staffrepo;
        private readonly IGenericRepo<Room> _roomrepo;

        public GuestController(IGuestRepo repo, IGenericRepo<Staff> staffrepo, IGenericRepo<Room> roomrepo)
        {
            _repo = repo;
            _staffrepo = staffrepo;
            _roomrepo = roomrepo;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateGuestDto dto)
        {
            if (dto == null) return BadRequest();

            var guest = new Guest()
            {
                Name = dto.Name,
                Email = dto.Email
            };

            if (dto.Staff?.Any() == true)
            {
                var staffs = await _staffrepo.GetAllAsync();
                var staffsforG = staffs.Where(x => dto.Staff.Contains(x.Id)).ToList();

                if(staffsforG.Count!=dto.Staff.Count|| staffsforG.IsNullOrEmpty())
                {
                    return BadRequest("Invalid Staff'Ids");
                }
                guest.Staff = staffsforG;
            }

            await _repo.Add(guest);
            await _repo.Save();

            if(dto.Room!=null)
            {
                var room = new Room()
                {
                    RoomNumber = dto.Room.RoomNumber,
                    Type = dto.Room.Type,
                    GuestId = guest.Id
                };
                await _roomrepo.Add(room);
                await _roomrepo.Save();
            }

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id , CreateGuestDto dto)
        {
            if (dto == null) return BadRequest();
            var guest = await _repo.GetGuestById(id);
            if (guest == null) return NotFound();

            guest.Name = dto.Name;
            guest.Email = dto.Email;

            if (dto.Staff?.Any() == true)
            {
                var staffs = await _staffrepo.GetAllAsync();
                var sForG = staffs.Where(x => dto.Staff.Contains(x.Id)).ToList();
                if (sForG.Count != dto.Staff.Count || sForG.IsNullOrEmpty())
                {
                    return BadRequest("Invalid'Ids");
                }
                guest.Staff= sForG;
            } 

            if (dto.Room != null)
            {
                if (guest.Room == null)
                {
                    var room = new Room()
                    {
                        RoomNumber = dto.Room.RoomNumber,
                        Type = dto.Room.Type,
                        GuestId = guest.Id
                    };
                    await _roomrepo.Add(room);
                    await _roomrepo.Save();
                }
                guest.Room.RoomNumber = dto.Room.RoomNumber;
                guest.Room.Type = dto.Room.Type;
            }
            await _repo.Update(guest);
            await _repo.Save();

            return Ok(dto);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guests = await _repo.GetAllGuests();
            if (guests == null) return BadRequest("No guests found");
            var dto = guests.Select(x => new ReadGuestDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                staffs = x.Staff != null ? x.Staff.Select(n => n.Name).ToList() : [],
                Room = x.Room != null ? new RoomForGuest()
                {
                    RoomNumber = x.Room.RoomNumber,
                    Type = x.Room.Type,
                }:null
            });
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Deleet(int id)
        {
            var guest = await _repo.GetGuestById(id);
            if (guest == null) return NotFound();
            await _repo.Delete(id);
            await _repo.Save();
            return NoContent();
        }
    }
}
