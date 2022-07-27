using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class ExamScheduleDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Exam Start Time is Required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "The Exam End Time is Required")]
        public DateTime EndTime { get; set; }
        //public DateTime Date { get; set; }
        [ForeignKey("Teacher")]
        public string TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("course")]
        public int? Course_ID { get; set; }
        public virtual Course course { get; set; }

        [ForeignKey("ExamSchedule")]
        public int? ExamSchedule_ID { get; set; }
        public virtual ExamSchedule ExamSchedule { get; set; }

    }
}
