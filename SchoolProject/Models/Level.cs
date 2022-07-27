using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Level Number is Required")]
        public int Number { get; set; }   
        public virtual List<Class> classes { get; set; }    
        public virtual List<Student> Students { get; set; }


        [ForeignKey("examScheduleDetails")]
        public int? examScheduleDetailsID { get; set; }
        public virtual ExamScheduleDetails examScheduleDetails { get; set; }
        [ForeignKey("HistoryOfStudend")]
        public int? HistoryOfStudendID { get; set; }
        public virtual HistoryOfStudend HistoryOfStudend { get; set; }

    }
}
