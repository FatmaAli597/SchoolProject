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
    public class StudentAttentanceController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<StudentAttentance> cRUD_Repository;

        public StudentAttentanceController(ICRUD_Repository<StudentAttentance> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<StudentAttentance> StudentAttentancees = cRUD_Repository.Getall();

            return Ok(StudentAttentancees);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentAttentance StudentAttentancees = cRUD_Repository.GetById(id);

            return Ok( StudentAttentancees);
        }
        [HttpPost]
        public IActionResult insert(StudentAttentance StudentAttentance)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int num= cRUD_Repository.Insert(StudentAttentance);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(StudentAttentance StudentAttentance)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Update(StudentAttentance);
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
