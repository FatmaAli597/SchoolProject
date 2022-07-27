using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Course Name is Required")]
        [MinLength(3, ErrorMessage = "Min Length of Course Name must be more then 3 char")]

        [MaxLength(100, ErrorMessage = "Max Length of Course Name must be more then 3 char")]
        public string Name { get; set; }    
        public virtual List<Teacher> Teachers { get; set; }

        [ForeignKey("level")]
        public int? LevelID { get; set; }
        public virtual Level level { get; set; }

        //[ForeignKey("courseTable")]
        //public int CourseTableID { get; set; }
        //public virtual CourseTable courseTable { get; set; }


    }
}
