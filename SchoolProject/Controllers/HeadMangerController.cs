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
    public class HeadMangerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Repository.ICrud_Repository1<HeadManager> cRUD_Repository;
        private readonly IuserRepository iuserRepository;

        public HeadMangerController(UserManager<ApplicationUser> userManager,
            ICrud_Repository1<HeadManager> cRUD_Repository
            , IuserRepository iuserRepository)
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
            List<HeadManager> headManagers = cRUD_Repository.Getall();
            
            return Ok(headManagers);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(string id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            HeadManager headManager = cRUD_Repository.GetById(id);

            return Ok(headManager);
        }
        [HttpPost]
        public async Task< IActionResult> insert(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await userManager.FindByEmailAsync(userDto.email) is not null)
                return BadRequest(new { Message = "Email is already registered!" });

            if (await userManager.FindByNameAsync(userDto.userName) is not null)
                return BadRequest(new { Message = "Username is already registered!" });
            HeadManager headManager = new HeadManager();
            headManager.UserName = userDto.userName;
            headManager.Email = userDto.email;
            headManager.Address = userDto.address;
            headManager.PhoneNumber = userDto.PhoneNumber;
            headManager.SSN = userDto.ssn;
            headManager.Image = userDto.image;
            headManager.PasswordHash = userManager.PasswordHasher.HashPassword(headManager, userDto.password);

            int num = cRUD_Repository.Insert(headManager);

            await userManager.AddToRoleAsync(headManager, "HeadManager");
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
            int num= cRUD_Repository.Delete(id);
            return Ok(num);
        }
    }
}
