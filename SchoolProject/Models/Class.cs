using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Class Name is Required")]
        [MinLength(3, ErrorMessage = "Min Length Class Name must be more then 3 char")]

        [MaxLength(100, ErrorMessage = "Max Length of name must be more then 3 char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Class Chair Number is Required")]
        public int ChairNumber { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        [ForeignKey("Level")]
        public int? LevelID { get; set; }
        public virtual Level Level { get; set; }
        public virtual List<Quiz> Quizs { get; set; }

        [ForeignKey("courseScheduleDetails")]
        public int? courseScheduleDetailsID { get; set; }
        public virtual CourseScheduleDetails courseScheduleDetails { get; set; }

        public virtual List<Course> Courses { get; set; }

        public virtual List<StudentAttentance> studentAttentances { get; set; }

    }
}
