using JsonBasedLocalization.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System.Collections.Generic;

namespace SchoolProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorHistoryController : ControllerBase
    {
        private readonly Repository.ICRUD_Repository<VistorHitory> cRUD_Repository;
        
        Context Context;
        public VisitorHistoryController(ICRUD_Repository<VistorHitory> cRUD_Repository,Context context)
        {
            this.cRUD_Repository = cRUD_Repository;
            this.Context = context;
        }
        [HttpPost]
        public IActionResult insert(Visitor_HistoryDTo Visitor_HistoryDTo)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VistorHitory VistorHitory = new VistorHitory();
            VistorHitory.Visit_Date = Visitor_HistoryDTo.Visit_Date;
            VistorHitory.VisitiorReason = Visitor_HistoryDTo.VisitiorReason;
            VistorHitory.Comment = Visitor_HistoryDTo.Comment;
            VistorHitory.ApplicationUserID = Visitor_HistoryDTo.ApplicationUserID;
            
            int num= cRUD_Repository.Insert(VistorHitory);
            return Ok(num);
          
        }
        [HttpGet]
        public IActionResult getall()
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List< VistorHitory >List = cRUD_Repository.Getall();
            return Ok(List);
        }
    }
}
