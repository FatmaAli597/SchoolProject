namespace SchoolProject.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public int Holiday { get; set; }
        public int AbsenceDays { get; set; }
        public string  ssn { get; set; }
        public string email { get; set; }
        public string PhoneNumber { get; set; }
        public int HeadManagerebusId { get; set; }

        public string  password{ get; set; }

        public int busStudentID { get; set; }
        public int busTeacherID { get; set; }
        public int classID { get; set; }
        public string parentID { get; set; }
        public int LevelID { get; set; }

        public int studyYearID { get; set; }
       
    }
}
