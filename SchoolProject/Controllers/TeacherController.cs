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
    public class TeacherController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Repository.ICrud_Repository1<Teacher> cRUD_Repository;
        private readonly IuserRepository iuserRepository;

        public TeacherController(UserManager<ApplicationUser> userManager,
            ICrud_Repository1<Teacher> cRUD_Repository,
            IuserRepository iuserRepository)
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

            List<Teacher> teachers = cRUD_Repository.Getall();

            return Ok( teachers);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(string id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Teacher teacher = cRUD_Repository.GetById(id);

            return Ok( teacher);
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


            Teacher teacher = new Teacher();
            teacher.UserName = userDto.userName;
            teacher.Email = userDto.email;
            teacher.Address = userDto.address;
            teacher.PhoneNumber = userDto.PhoneNumber;
            teacher.SSN = userDto.ssn;
            teacher.busTeacherID=userDto.busTeacherID;
            teacher.Image = userDto.image;
            teacher.PasswordHash = userManager.PasswordHasher.HashPassword(teacher, userDto.password);

            int num = cRUD_Repository.Insert(teacher);

            await userManager.AddToRoleAsync(teacher, "Teacher");
            return Ok(num);
        }
        [HttpPut("{ID}")]
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
