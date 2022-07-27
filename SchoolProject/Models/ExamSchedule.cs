using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class ExamSchedule
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Term is Required")]
        public int Term { get; set; }
        [ForeignKey("level")]
        public int? Level_ID { get; set; }
        public virtual Level level { get; set; }

    }
}
