using SchoolProject.Models;
using System.Collections.Generic;

namespace SchoolProject.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int  LevelID { get; set; }
        //public List<Teacher> teachers { get; set; }
    }
}
