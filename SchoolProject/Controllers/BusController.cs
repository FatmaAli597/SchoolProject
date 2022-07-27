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
    public class BusController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<Bus> cRUD_Repository;

        public BusController(ICRUD_Repository<Bus> cRUD_Repository)
        {
            this.cRUD_Repository = cRUD_Repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Bus> buses = cRUD_Repository.Getall();

            return Ok(buses);
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyID(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            Bus buses = cRUD_Repository.GetById(id);

            return Ok(buses);
        }
        [HttpPost]
        public IActionResult insert(BusDto busTdo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Bus bus = new Bus();
            bus.BusNumber = busTdo.BusNumber;
            bus.BusChairNumber = busTdo.BusChairNumber;
            bus.BusDriverName = busTdo.BusDriverName;
            bus.ApplicationUserID = busTdo.ApplicationUserID;
            bus.BusLineID = busTdo.BusLineID;
            bus.Users = busTdo.Users;

            int num= cRUD_Repository.Insert(bus);
            return Ok(num);
        }
        [HttpPut]
        public IActionResult Edit(BusDto busTdo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Bus bus = new Bus();
            bus.Id = busTdo.Id;
            bus.BusNumber = busTdo.BusNumber;
            bus.BusChairNumber = busTdo.BusChairNumber;
            bus.BusDriverName = busTdo.BusDriverName;
            bus.ApplicationUserID = busTdo.ApplicationUserID;
            bus.BusLineID = busTdo.BusLineID;
            bus.Users = busTdo.Users;
            int num= cRUD_Repository.Update(bus);
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
