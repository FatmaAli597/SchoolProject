using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("Teacher")]
    public class Teacher :ApplicationUser
    {


        [ForeignKey("busTeacher")]
        public int? busTeacherID { get; set; }
        public virtual Bus busTeacher { get; set; }

        public virtual List<Course> courses { get; set; }

     //   public virtual List<CourseTable> courseTable { get; set; }
        
        public virtual List<Class> Classes { get; set; }
        public virtual List<StaffAttentance> staffAttentances { get; set; }
 
    }
}
