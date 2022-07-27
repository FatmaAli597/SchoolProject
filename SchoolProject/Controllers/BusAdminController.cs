using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BusAdminController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<BusAdmin> cRUD_Repository;
        private readonly IuserRepository iuserRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public BusAdminController(UserManager<ApplicationUser> userManager,
            ICrud_Repository1<BusAdmin> cRUD_Repository,IuserRepository iuserRepository)
        {

            _userManager = userManager;
            this.cRUD_Repository = cRUD_Repository;
            this.iuserRepository = iuserRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<BusAdmin> busAdmins = cRUD_Repository.Getall();


            return Ok(busAdmins);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BusAdmin busAdmin = cRUD_Repository.GetById(id);

            return Ok(busAdmin);
        }
        [HttpPost]
        public async Task<IActionResult> insert(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _userManager.FindByEmailAsync(userDto.email) is not null)
                return BadRequest(new { Message = "Email is already registered!" });

            if (await _userManager.FindByNameAsync(userDto.userName) is not null)
                return BadRequest(new { Message = "Username is already registered!" });

            BusAdmin busAdmin = new BusAdmin();
            busAdmin.UserName = userDto.userName;
            busAdmin.Email = userDto.email;
            busAdmin.Address = userDto.address;
            busAdmin.PhoneNumber = userDto.PhoneNumber;
            busAdmin.SSN = userDto.ssn;
            busAdmin.Image = userDto.image;
            busAdmin.PasswordHash = _userManager.PasswordHasher.HashPassword(busAdmin, userDto.password);

            int num = cRUD_Repository.Insert(busAdmin);

            await _userManager.AddToRoleAsync(busAdmin, "BusAdmin");

            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(string ID, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            ApplicationUser user1 = iuserRepository.Edit(ID, userDto);
            return Ok(user1);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

        int num=cRUD_Repository.Delete(id);
            return Ok(num);
        }
    }
}
