using System;

namespace SchoolProject.Dtos
{
    public class ExamScheduleDetailsDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
       public DateTime EndTime { get; set; }
       public string TeacherID { get; set; }
       public int Course_ID { get; set; }
       public int ExamSchedule_ID { get; set; }
    }
}
