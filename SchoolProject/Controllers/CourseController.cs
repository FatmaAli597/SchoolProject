using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Course> cRUD_Repository;
        public CourseController(ICRUD_Repository<Course> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Course> courses = cRUD_Repository.Getall();

            return Ok(courses);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Course Course = cRUD_Repository.GetById(id);

            return Ok(Course);
        }
        [HttpPost]
        public IActionResult insert(CourseDto courseDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Course course = new Course();
            course.Name= courseDto.Name;
            course.LevelID= courseDto.LevelID;
            int num = cRUD_Repository.Insert(course);
            return Ok(num);
       }
        [HttpPut]
        public IActionResult Edit(CourseDto courseDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Course course = new Course();
            course.Id = courseDto.Id;
            course.Name = courseDto.Name;
            course.LevelID = courseDto.LevelID;
            int num= cRUD_Repository.Update(course);
            return Ok(num);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Delete(id);
            return Ok(num);

        }
        [HttpGet("/Courseoflevel")]
        public IActionResult getallstdbylvlid(int lvlid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Course> courses = cRUD_Repository.Getall().Where(std => std.LevelID == lvlid).ToList();
            return Ok(courses);


        }

    }
}
