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
    public class CourseScheduleController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<CourseSchedule> cRUD_Repository;

        public CourseScheduleController(ICRUD_Repository<CourseSchedule> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<CourseSchedule> CourseSchedulees = cRUD_Repository.Getall();

            return Ok(CourseSchedulees);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CourseSchedule CourseSchedulees = cRUD_Repository.GetById(id);

            return Ok( CourseSchedulees);
        }
        [HttpPost]
        public IActionResult insert(CourseScheduleDto courseScheduleDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CourseSchedule courseSchedule = new CourseSchedule();
            courseSchedule.Term = courseScheduleDto.Term;
            courseSchedule.Level_ID = courseScheduleDto.Level_ID;
            courseSchedule.Class_ID=courseScheduleDto.Class_ID;
            int num= cRUD_Repository.Insert(courseSchedule);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(CourseScheduleDto courseScheduleDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CourseSchedule courseSchedule = new CourseSchedule();
            courseSchedule.Id = courseSchedule.Id;
            courseSchedule.Term = courseScheduleDto.Term;
            courseSchedule.Level_ID = courseScheduleDto.Level_ID;
            courseSchedule.Class_ID = courseScheduleDto.Class_ID;
            int num = cRUD_Repository.Update(courseSchedule);
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

    }
}
