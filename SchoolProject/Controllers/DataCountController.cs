using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataCountController : ControllerBase
    {
        private readonly ICountrepository countrepository;

        public DataCountController(ICountrepository countrepository) 
        {
            this.countrepository = countrepository;
        }
        [HttpGet("/users")]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountOfUsers();

            return Ok(num);
        }
        [HttpGet("/Students")]
        public IActionResult StudentCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountOfStudent();

            return Ok(num);
        }
    [HttpGet("/parents")]
        public IActionResult ParentsCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountParents();

            return Ok(num);
        }
        [HttpGet("/teacher")]
        public IActionResult teacherCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountOfTeacher();

            return Ok(num);
        }
        [HttpGet("/manager")]
        public IActionResult managerCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountOfManager();

            return Ok(num);
        }
         [HttpGet("/Headmanager")]
        public IActionResult HeadmanagerCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountOfHeadManager();

            return Ok(num);
        }
        [HttpGet("/Resptionst")]
        public IActionResult ResptionstCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountResptionst();

            return Ok(num);
        }
        [HttpGet("/Visitior")]
        public IActionResult VisitiortCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountVisitiors();

            return Ok(num);
        }
        [HttpGet("/Adminbus")]
        public IActionResult AdminbusCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountAdminbus();

            return Ok(num);
        }
      [HttpGet("/Classes")]
        public IActionResult ClassesCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountClasses();

            return Ok(num);
        }
      [HttpGet("/Levels")]
        public IActionResult LevelsCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountLevels();

            return Ok(num);
        }
       [HttpGet("/BusLines")]
        public IActionResult BusLinesCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountBusLines();

            return Ok(num);
        }
       [HttpGet("/Bus")]
        public IActionResult BusCount()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int num = countrepository.GetCountBuss();

            return Ok(num);
        }
      
    }
}
