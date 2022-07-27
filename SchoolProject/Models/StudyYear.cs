using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class StudyYear
    {
        public int Id { get; set; }
        public DateTime Start_StudyYear { get; set; }
        public DateTime? End_StudyYear { get; set; }
        public virtual List<Student> students { get; set; }
        [ForeignKey("HistoryOfStudend")]
        public int? HistoryOfStudendID { get; set; }
        public virtual HistoryOfStudend HistoryOfStudend { get; set; }




    }
}
