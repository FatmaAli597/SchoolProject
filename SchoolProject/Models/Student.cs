using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("Student")]
    public class Student :ApplicationUser
    {
       
        
        public int Holiday { get; set; }
        public int AbsenceDays { get; set; }
        [ForeignKey("parent")]
        public string ParentID { get; set; }
        public virtual Parent parent { get; set; }

        [ForeignKey("busStudent")]
        public int? busStudentID { get; set; }
        public virtual Bus busStudent { get; set; }

        [ForeignKey("classes")]
        public int? classId { get; set; }
        public virtual Class classes { get; set; }

        [ForeignKey("Level")]
        public int? LevelId { get; set; }
        public virtual Level Level { get; set; }

        public int? counterForLevel { get; set; }
        //[ForeignKey("studentAttentance")]
        //public int studentAttentanceId { get; set; }

        [ForeignKey("studyYear")]
        public int? studyYearID { get; set; }
        public virtual StudyYear studyYear { get; set; }
        public virtual List<StudentAttentance> studentAttentance { get; set; }
        [ForeignKey("HistoryOfStudend")]
        public int? HistoryOfStudendID { get; set; }
        public virtual HistoryOfStudend HistoryOfStudend { get; set; }
 
    }
}
