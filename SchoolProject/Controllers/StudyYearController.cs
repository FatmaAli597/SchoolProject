using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudyYearController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<StudyYear> cRUD_Repository;

        public StudyYearController(ICRUD_Repository<StudyYear> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<StudyYear> StudyYeares = cRUD_Repository.Getall();

            return Ok( StudyYeares);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudyYear StudyYeares = cRUD_Repository.GetById(id);

            return Ok( StudyYeares);
        }
        [HttpPost]
        public IActionResult insert(StudyYear StudyYear)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int num= cRUD_Repository.Insert(StudyYear);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(StudyYear StudyYear)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Update(StudyYear);
            return Ok(num);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Delete(id);
            return Ok(num);

        }

    }
}
