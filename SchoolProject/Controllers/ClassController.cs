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
    public class ClassController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Class> cRUD_Repository;
        public ClassController(ICRUD_Repository<Class> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Class> classes= cRUD_Repository.Getall();

            return Ok(classes);
            
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Class Class = cRUD_Repository.GetById(id);

            return Ok(Class);
        }
        [HttpPost]
        public IActionResult insert(ClassDto classDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Class Class = new Class();
            Class.ChairNumber = classDto.ChairNumber;
            Class.Name = classDto.Name;
            Class.LevelID = classDto.LevelID;
            int num = cRUD_Repository.Insert(Class);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(ClassDto classDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Class Class = new Class();
            Class.Id = classDto.Id;
            Class.ChairNumber = classDto.ChairNumber;
            Class.Name = classDto.Name;
            Class.LevelID = classDto.LevelID;
            int num = cRUD_Repository.Update(Class);
            return Ok(num);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num =cRUD_Repository.Delete(id);
            return Ok(num);
        }
        [HttpGet("/classoflevel")]
        public IActionResult getallstdbylvlid(int lvlid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Class> classes = cRUD_Repository.Getall().Where(std => std.LevelID == lvlid).ToList();
            return Ok(classes); 


        }
        
    }
}
