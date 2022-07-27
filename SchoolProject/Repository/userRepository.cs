using Microsoft.AspNetCore.Identity;
using SchoolProject.Dtos;
using SchoolProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class userRepository : IuserRepository
    {
        private readonly Context context;
        private readonly UserManager<ApplicationUser> userManager;

        public userRepository(Context context, Context _context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public ApplicationUser Edit(string ID, UserDto newuser)
        {
            ApplicationUser user = context.Users.FirstOrDefault(user => user.Id == ID);
            user.UserName = newuser.userName;
            user.Email = newuser.email;
            user.PhoneNumber = newuser.PhoneNumber;
            user.Image = newuser.image;
            user.SSN = newuser.ssn;
            user.Address = newuser.address;
            user.Gender = newuser.gender;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, newuser.password);

            context.SaveChanges();
            return user;
        }
    }
}
