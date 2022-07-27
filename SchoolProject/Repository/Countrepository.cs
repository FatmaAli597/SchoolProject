using Microsoft.AspNetCore.Identity;
using SchoolProject.Models;
using System.Linq;

namespace SchoolProject.Repository
{
    public class Countrepository : ICountrepository
    {
        private Context context;
        public Countrepository(Context _context)
        {
            this.context = _context;
        }
        public int GetCountOfUsers()
        {
            int num = context.Users.Count();
            return num;
        }
        public int GetCountOfStudent()
        {
            int num = context.Students.Count();
            return num;
        }
        public int GetCountOfTeacher()
        {
            int num = context.Teachers.Count();
            return num;
        }
        public int GetCountOfManager()
        {
            int num = context.Managers.Count();
            return num;
        }
        public int GetCountOfHeadManager()
        {
            int num = context.HeadManager.Count();
            return num;
        }
        public int GetCountAdminbus()
        {
            int num = context.BusAdmins.Count();
            return num;
        }
        public int GetCountResptionst()
        {
            int num = context.Receptionists.Count();
            return num;
        }
        public int GetCountVisitiors()
        {
            int num = context.Visitiors.Count();
            return num;
        }
        public int GetCountParents()
        {
            int num = context.Parents.Count();
            return num;
        }
        public int GetCountLevels()
        {
            int num = context.Levels.Count();
            return num;
        }
        public int GetCountClasses()
        {
            int num = context.Classes.Count();
            return num;
        }
        public int GetCountBuss()
        {
            int num = context.Buss.Count();
            return num;
        }
        public int GetCountBusLines()
        {
            int num = context.BusLines.Count();
            return num;
        }



    }
}
