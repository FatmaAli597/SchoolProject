
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Dtos;
using SchoolProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class stdrepo : Istdrepo
    {
        // Istdrepo


        private Context context;
        private readonly UserManager<ApplicationUser> userManager;

        public stdrepo(Context _context, UserManager<ApplicationUser> userManager)
        {
            this.context = _context;
            this.userManager = userManager;
        }
        public async Task<ApplicationUser> GetByemail(string email)
        {

            /// Fetch the user object
            //Student student = context.Students.FirstOrDefault(s => s.Email == email);
            //return student;
            //var user = await userManager.FindByEmailAsync(email);
            var user = await userManager.FindByNameAsync(email);

            return user;
        }
        public Class StudentClass(int classId)
        {
            Class cls =
                context.Classes
                .Include(c => c.Level)
                .Include(c => c.courseScheduleDetails)
                .Include(c => c.Courses)
                .Include(c => c.Teachers).AsSplitQuery()
                .FirstOrDefault(cls => cls.Id == classId);
            //;
            //Level level= cls.Level;
            //CourseScheduleDetails courseSchedules = cls.courseScheduleDetails;
            //List<Quiz> quiz = cls.Quizs;
            //List<Course> courses = cls.Courses;
            //List<Teacher> teachers = cls.Teachers;

            return cls;

        }


        public Student EditStd(string ID, UserDto newStd)
        {

            Student user = context.Students.FirstOrDefault(std=>std.Id==ID); 
            user.UserName= newStd.userName;
            user.Email=newStd.email;
            user.PhoneNumber=newStd.PhoneNumber;
            user.Image= newStd.image;
            user.SSN=newStd.ssn;
            user.Address = newStd.address;
            user.AbsenceDays = newStd.AbsenceDays;
            user.Holiday=newStd.Holiday;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, newStd.password);

            context.SaveChanges();
            return user;



        }


       
    }
}