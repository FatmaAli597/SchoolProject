using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
 
    public class StudentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Repository.ICrud_Repository1<Student> cRUD_Repository;
        private readonly Istdrepo istdrepo;
        

        public StudentController(UserManager<ApplicationUser> userManager,
            ICrud_Repository1<Student> cRUD_Repository, 
            Istdrepo istdrepo)
        {
            this.userManager = userManager;
            this.cRUD_Repository = cRUD_Repository;
            this.istdrepo = istdrepo;
            
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Student> students = cRUD_Repository.Getall();

            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(string id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student student = cRUD_Repository.GetById(id);

            return Ok(student);
        }
        //[Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> getemail(string email)
        {

            ApplicationUser student = await istdrepo.GetByemail(email);
            return Ok(student);
        }
        // [Authorize]
        [HttpGet("Studentclass/{classID}")]
        public IActionResult getStudentClass(int classID)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Class cls = istdrepo.StudentClass(classID);
            ClassDto classDto = new ClassDto();
            classDto.ChairNumber = cls.ChairNumber;
            classDto.Name = cls.Name;
            classDto.levelNumber = cls.Level.Number;
            classDto.courseScheduleDetailsDto.EndTime = cls.courseScheduleDetails.EndTime;
            classDto.courseScheduleDetailsDto.Course_Name = cls.courseScheduleDetails.course.Name;

            classDto.courseScheduleDetailsDto.StartTime = cls.courseScheduleDetails.StartTime;
            // classDto.courseScheduleDetailsDto = cls.courseScheduleDetails;
            foreach (var itme in cls.Courses)
            {
                if (itme.Name != null)
                {
                    classDto.courseNAme.Add(itme.Name);

                }
            }
            foreach (var itme in cls.Teachers)
            {
                if (itme.UserName != null)
                { classDto.teacherNames.Add(itme.UserName); }
            }


            return Ok(classDto);
        }


        [HttpPost]
        public async Task<IActionResult> insert(UserDto userDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await userManager.FindByEmailAsync(userDto.email) is not null)
                return BadRequest (new { Message = "Email is already registered!" });
            if (await userManager.FindByNameAsync(userDto.userName) is not null)
                return BadRequest( new{ Message = "Username is already registered!" });

            Student student = new Student();
            student.UserName = userDto.userName;
            student.Email = userDto.email;
            student.Address = userDto.address;
            student.PhoneNumber = userDto.PhoneNumber;
            student.SSN = userDto.ssn;
            student.Holiday = userDto.Holiday;
            student.AbsenceDays = userDto.AbsenceDays;
            student.Image = userDto.image;
            student.PasswordHash = userManager.PasswordHasher.HashPassword(student, userDto.password) ;
            student.busStudentID = userDto.busStudentID;
            student.classId = userDto.classID;
            student.ParentID = userDto.parentID;
            student.LevelId = userDto.LevelID;
            student.studyYearID = userDto.studyYearID;

            int num = cRUD_Repository.Insert(student);

            await userManager.AddToRoleAsync(student, "Student");


            return Ok(num);
        }
        [HttpPut("{ID}")]
        public IActionResult Edit([FromRoute]string ID,[FromBody] UserDto userDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          
            ApplicationUser student1 =  istdrepo.EditStd(ID, userDto);
            return Ok(student1);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Delete(id);
            return Ok(num);

        }
        [HttpGet("/stdoflevel")]
        public IActionResult getallstdbylvlid(int lvlid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Student> Students = cRUD_Repository.Getall().Where(std => std.LevelId == lvlid).ToList();
           
            return Ok(Students);


        }








    }
}
