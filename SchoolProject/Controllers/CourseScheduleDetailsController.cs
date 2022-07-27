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
    public class CourseScheduleDetailsController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<CourseScheduleDetails> cRUD_Repository;

        public CourseScheduleDetailsController(ICRUD_Repository<CourseScheduleDetails> cRUD_Repository)
        {

            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<CourseScheduleDetails> CourseScheduleDetailses = cRUD_Repository.Getall();

            return Ok( CourseScheduleDetailses);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CourseScheduleDetails CourseScheduleDetailses = cRUD_Repository.GetById(id);

            return Ok(CourseScheduleDetailses);
        }
        [HttpPost]
        public IActionResult insert(CourseScheduleDetailsDto courseScheduleDetailsDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CourseScheduleDetails courseScheduleDetails=new CourseScheduleDetails();
            courseScheduleDetails.StartTime= courseScheduleDetailsDto.StartTime;
            courseScheduleDetails.EndTime= courseScheduleDetailsDto.EndTime;
            courseScheduleDetails.CourseSchedule_ID= courseScheduleDetailsDto.CourseSchedule_ID;
            courseScheduleDetails.ApplicationUserID=courseScheduleDetailsDto.ApplicationUserID;
            int num= cRUD_Repository.Insert(courseScheduleDetails);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(CourseScheduleDetailsDto courseScheduleDetailsDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CourseScheduleDetails courseScheduleDetails = new CourseScheduleDetails();
            courseScheduleDetails.Id = courseScheduleDetailsDto.Id;
            courseScheduleDetails.StartTime = courseScheduleDetailsDto.StartTime;
            courseScheduleDetails.EndTime = courseScheduleDetailsDto.EndTime;
            courseScheduleDetails.CourseSchedule_ID = courseScheduleDetailsDto.CourseSchedule_ID;
            courseScheduleDetails.ApplicationUserID = courseScheduleDetailsDto.ApplicationUserID;

            int num= cRUD_Repository.Update(courseScheduleDetails);
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
