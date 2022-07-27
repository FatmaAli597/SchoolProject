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

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Level> cRUD_Repository;

        public LevelController(ICRUD_Repository<Level> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            List<Level> Leveles = cRUD_Repository.Getall();

            return Ok( Leveles);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Level Leveles = cRUD_Repository.GetById(id);

            return Ok( Leveles);
        }
        [HttpPost]
        public IActionResult insert(LevelDto levelDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Level level=new Level();
            level.Number = levelDto.Number;
            level.HistoryOfStudendID = levelDto.HistoryOfStudendID;
            int num = cRUD_Repository.Insert(level);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(LevelDto levelDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Level level = new Level();
            level.Id = levelDto.Id;
            level.Number = levelDto.Number;
            level.HistoryOfStudendID = levelDto.HistoryOfStudendID;
            int num = cRUD_Repository.Update(level);
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
