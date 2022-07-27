using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class VistorHitory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Vistor Date Time is Required")]
        public DateTime Visit_Date { get; set; }

        [Required(ErrorMessage = "The Visitior Reason is Required")]
        public string VisitiorReason { get; set; }
        public string Comment { get; set; }
        //[ForeignKey("visitior")]
        //public int? Visitor_id { get; set; }
        //public virtual Visitior visitior { get; set; }

        //[ForeignKey("receptionist")]
        //public int? receptionistID { get; set; }
        //public virtual Receptionist receptionist { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
