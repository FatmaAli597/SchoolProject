using SchoolProject.Models;
using System.Collections.Generic;

namespace SchoolProject.Dtos
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  ChairNumber { get; set; }
        public int LevelID { get; set; }
        public int levelNumber { get; set; }

        public List<string> courseNAme { get; set; }=new List<string>();
        public List< string>teacherNames { get; set; } = new List<string>();

        public CourseScheduleDetailsDto courseScheduleDetailsDto { get; set; } = new CourseScheduleDetailsDto();
         

    }
}
