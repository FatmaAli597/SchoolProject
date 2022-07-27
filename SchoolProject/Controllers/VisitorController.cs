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
    public class VisitorController : ControllerBase
    {
        private readonly Repository.ICrud_Repository1<Visitior> cRUD_Repository;
        private readonly IuserRepository iuserRepository;

        public VisitorController(ICrud_Repository1<Visitior> cRUD_Repository,
            IuserRepository iuserRepository)
        {
            this.cRUD_Repository = cRUD_Repository;
            this.iuserRepository = iuserRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Visitior> visitiors= cRUD_Repository.Getall();

            return Ok( visitiors);
        }
        [HttpGet("{id}")]
        public IActionResult getbyID(string id)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Visitior visitior = cRUD_Repository.GetById(id);

            return Ok( visitior);
        }
        [HttpPost]
        public IActionResult insert(UserDto userDto)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            Visitior visitior =new Visitior();
            visitior.UserName = userDto.userName;
            visitior.Email = userDto.email;
            visitior.Address = userDto.address;
            visitior.PhoneNumber = userDto.PhoneNumber;
            visitior.SSN = userDto.ssn;
            visitior.Gender=userDto.gender;
            visitior.Image = userDto.image;
            int num = cRUD_Repository.Insert(visitior);
            return Ok(num);
        }

        [HttpPut("{ID}")]
        public IActionResult Edit(string ID, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            ApplicationUser user1 = iuserRepository.Edit(ID, userDto);
            return Ok(user1);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num= cRUD_Repository.Delete(id);
            return Ok(num);
        }

    }
}
