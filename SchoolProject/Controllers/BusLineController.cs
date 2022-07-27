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
    public class BusLineController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<BusLine> cRUD_Repository;

        public BusLineController(ICRUD_Repository<BusLine> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<BusLine> BusLinees = cRUD_Repository.Getall();

            return Ok(BusLinees);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BusLine BusLinees = cRUD_Repository.GetById(id);

            return Ok(BusLinees);
        }
        [HttpPost]
        public IActionResult insert(BusLineDto busLineDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            BusLine busLine=new BusLine();
            busLine.address = busLineDto.address;
            busLine.LineName = busLineDto.LineName;
           
            int num = cRUD_Repository.Insert(busLine);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(BusLineDto busLineDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BusLine busLine = new BusLine();
            busLine.Id = busLineDto.Id;
            busLine.address = busLineDto.address;
            busLine.LineName = busLineDto.LineName;
            int num= cRUD_Repository.Update(busLine);
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
