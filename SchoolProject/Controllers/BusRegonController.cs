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
    public class BusRegonController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<BusRegon> cRUD_Repository;

        public BusRegonController(ICRUD_Repository<BusRegon> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<BusRegon> busRegons = cRUD_Repository.Getall();

            return Ok(busRegons);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BusRegon busRegons = cRUD_Repository.GetById(id);

            return Ok(busRegons);
        }

        [HttpPost]
        public IActionResult insert(RegonDto regonDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BusRegon busRegon= new BusRegon();
            busRegon.address = regonDto.address;
            busRegon.RegonName = regonDto.RegonName;    
           
            int num= cRUD_Repository.Insert(busRegon);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(RegonDto regonDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BusRegon busRegon = new BusRegon();
            busRegon.Id = regonDto.Id;
            busRegon.address = regonDto.address;
            busRegon.RegonName = regonDto.RegonName;
            int num =  cRUD_Repository.Update(busRegon);
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
