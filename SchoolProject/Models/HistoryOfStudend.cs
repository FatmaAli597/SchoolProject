using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class HistoryOfStudend
    {
        public int Id { get; set; }
        //[ForeignKey("Student")]
        //public int? StudentID { get; set; }
        //public virtual Student Student { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Level")]
        public int? LevelID { get; set; }
        public virtual Level Level { get; set; }
        [ForeignKey("StudyYear")]
        public int? StudyYearID { get; set; }
        public virtual StudyYear StudyYear { get; set; }
    }
}
