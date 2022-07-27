using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Dtos;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;

namespace SchoolProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class historyofstudentController : ControllerBase
    {

        private readonly Repository.ICRUD_Repository<HistoryOfStudend> cRUD_Repository;

        public historyofstudentController(ICRUD_Repository<HistoryOfStudend> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<HistoryOfStudend> historyOfStudends = cRUD_Repository.Getall();

            return Ok(historyOfStudends);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            HistoryOfStudend historyOfStudend = cRUD_Repository.GetById(id);

            return Ok(historyOfStudend);
        }
        [HttpPost]
        public IActionResult insert(Studenthistorydto studenthistorydto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            HistoryOfStudend historyOfStudend = new HistoryOfStudend();
            historyOfStudend.ApplicationUserID = studenthistorydto.applicationUserID;
            historyOfStudend.LevelID = studenthistorydto.levelID;
            historyOfStudend.StudyYearID = studenthistorydto.studyYearID;

            int num = cRUD_Repository.Insert(historyOfStudend);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(Studenthistorydto studenthistorydto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            HistoryOfStudend historyOfStudend = new HistoryOfStudend();
            historyOfStudend.Id = studenthistorydto.id;
            historyOfStudend.ApplicationUserID = studenthistorydto.applicationUserID;
            historyOfStudend.LevelID = studenthistorydto.levelID;
            historyOfStudend.StudyYearID = studenthistorydto.studyYearID;
            int num = cRUD_Repository.Update(historyOfStudend);
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
