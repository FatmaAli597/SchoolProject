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
    public class QuizController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Quiz> cRUD_Repository;

        public QuizController(ICRUD_Repository<Quiz> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Quiz> Quizes = cRUD_Repository.Getall();

            return Ok( Quizes);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Quiz Quizes = cRUD_Repository.GetById(id);

            return Ok( Quizes);
        }
        [HttpPost]
        public IActionResult insert(Quiz Quiz)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Insert(Quiz);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(Quiz Quiz)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Update(Quiz);
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
