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
    public class ExamScheduleDetailsController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<ExamScheduleDetails > cRUD_Repository;

        public ExamScheduleDetailsController(ICRUD_Repository<ExamScheduleDetails > cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<ExamScheduleDetails > ExamScheduleDetails = cRUD_Repository.Getall();

            return Ok(ExamScheduleDetails) ;
        }
        [HttpGet("{id}")]
        public IActionResult  getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ExamScheduleDetails  ExamScheduleDetails  = cRUD_Repository.GetById(id);

            return Ok(ExamScheduleDetails );
        }
        [HttpPost]
        public IActionResult insert(ExamScheduleDetailsDto  examScheduleDetailsDto )
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ExamScheduleDetails examScheduleDetails = new ExamScheduleDetails();
            examScheduleDetails.StartTime = examScheduleDetailsDto.StartTime;
            examScheduleDetails.EndTime = examScheduleDetailsDto.EndTime;
            examScheduleDetails.Course_ID = examScheduleDetailsDto.Course_ID;
            examScheduleDetails.TeacherID = examScheduleDetailsDto.TeacherID;
            examScheduleDetails.ExamSchedule_ID = examScheduleDetailsDto.ExamSchedule_ID;


            int num= cRUD_Repository.Insert(examScheduleDetails);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(ExamScheduleDetailsDto examScheduleDetailsDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ExamScheduleDetails examScheduleDetails = new ExamScheduleDetails();
            examScheduleDetails.Id = examScheduleDetailsDto.Id;
            examScheduleDetails.StartTime = examScheduleDetailsDto.StartTime;
            examScheduleDetails.EndTime = examScheduleDetailsDto.EndTime;
            examScheduleDetails.Course_ID = examScheduleDetailsDto.Course_ID;
            examScheduleDetails.TeacherID = examScheduleDetailsDto.TeacherID;
            examScheduleDetails.ExamSchedule_ID = examScheduleDetailsDto.ExamSchedule_ID;

            int num= cRUD_Repository.Update(examScheduleDetails );
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
