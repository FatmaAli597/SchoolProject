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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Repository.ICrud_Repository1<Manager> cRUD_Repository;
        private readonly IuserRepository iuserRepository;

        public ManagerController(UserManager<ApplicationUser> userManager,
            ICrud_Repository1<Manager> cRUD_Repository, IuserRepository iuserRepository)
        {
            this.userManager = userManager;
            this.cRUD_Repository = cRUD_Repository;
            this.iuserRepository = iuserRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Manager> managers = cRUD_Repository.Getall();

            return Ok(managers);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(string id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Manager manager = cRUD_Repository.GetById(id);

            return Ok(manager);
        }
        [HttpPost]
        public async Task<IActionResult> insert(UserDto userDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await userManager.FindByEmailAsync(userDto.email) is not null)
                return BadRequest(new { Message = "Email is already registered!" });


            if (await userManager.FindByNameAsync(userDto.userName) is not null)
                return BadRequest(new { Message = "Username is already registered!" });
            Manager manager = new Manager();
            manager.UserName = userDto.userName;
            manager.Email = userDto.email;
            manager.Address = userDto.address;
            manager.PhoneNumber = userDto.PhoneNumber;
            manager.SSN = userDto.ssn;
            manager.Image = userDto.image;

            manager.PasswordHash = userManager.PasswordHasher.HashPassword(manager, userDto.password);
            int num = cRUD_Repository.Insert(manager);

            await userManager.AddToRoleAsync(manager, "Manager");
            return Ok(num);
        }
        [HttpPut("{ID}")]
        public IActionResult Edit([FromRoute]string ID,[FromBody] UserDto userDto)
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
            int num= cRUD_Repository.Delete(id);
            return Ok(num);

        }
    }
}
