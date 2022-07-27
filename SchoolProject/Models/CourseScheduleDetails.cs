using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class CourseScheduleDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Course Start Time is Required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "The Course End Time is Required")]
        public DateTime EndTime { get; set; }
        //public DateTime Date { get; set; }
        //[ForeignKey("Teacher")]
        //public int? TeacherID { get; set; }
        //public virtual Teacher Teacher { get; set; }
        [ForeignKey("course")]
        public int? Course_ID { get; set; }
        public virtual Course course { get; set; }
        [ForeignKey("CourseSchedule")]
        public int? CourseSchedule_ID { get; set; }
        public virtual CourseSchedule CourseSchedule { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
