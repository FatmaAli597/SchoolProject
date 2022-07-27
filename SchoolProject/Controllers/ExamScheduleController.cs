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
    public class ExamScheduleController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<ExamSchedule> cRUD_Repository;

        public ExamScheduleController(ICRUD_Repository<ExamSchedule> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            List<ExamSchedule> ExamSchedulees = cRUD_Repository.Getall();

            return Ok(ExamSchedulees);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ExamSchedule ExamSchedulees = cRUD_Repository.GetById(id);

            return Ok(ExamSchedulees);
        }
        [HttpPost]
        public IActionResult insert(ExamScheduleDto examScheduleDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ExamSchedule examSchedule = new ExamSchedule();
            examSchedule.Term=examScheduleDto.Term;
            examSchedule.Level_ID=examScheduleDto.Level_ID;
            int num= cRUD_Repository.Insert(examSchedule);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(ExamScheduleDto examScheduleDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ExamSchedule examSchedule = new ExamSchedule();
            examSchedule.Id = examScheduleDto.Id;
            examSchedule.Term = examScheduleDto.Term;
            examSchedule.Level_ID = examScheduleDto.Level_ID;
            int num = cRUD_Repository.Update(examSchedule);
            return Ok(num);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int num = cRUD_Repository.Delete(id);
            return Ok(num);

        }

    }
}
