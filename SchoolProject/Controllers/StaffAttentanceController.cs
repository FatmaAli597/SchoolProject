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
    public class StaffAttentanceController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<StaffAttentance> cRUD_Repository;

        public StaffAttentanceController(ICRUD_Repository<StaffAttentance> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<StaffAttentance> StaffAttentancees = cRUD_Repository.Getall();

            return Ok( StaffAttentancees);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StaffAttentance StaffAttentancees = cRUD_Repository.GetById(id);

            return Ok( StaffAttentancees);
        }
        [HttpPost]
        public IActionResult insert(StaffAttentance StaffAttentance)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Insert(StaffAttentance);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(StaffAttentance StaffAttentance)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Update(StaffAttentance);
            return Ok(num);

        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = cRUD_Repository.Delete(id);
            return Ok(num);
        }

    }
}
