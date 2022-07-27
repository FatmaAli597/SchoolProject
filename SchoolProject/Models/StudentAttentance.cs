using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class StudentAttentance
    {
        public int Id { get; set; }
        public DateTime time { get; set; }
        /// الحصه الدراسيه الحصه الاوله التانيه....

        [Required(ErrorMessage = "The Study Class is Required")]
        public string StudyClass { get; set; }

        [Required(ErrorMessage = "The Student absent is Required")]
        public bool Isabsent { get; set; }
        [ForeignKey("studentAttendance")]
        public string studentAttendanceID { get; set; }
        public virtual Student studentAttendance { get; set; }
    }
}
