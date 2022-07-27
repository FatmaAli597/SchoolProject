using SchoolProject.Dtos;
using SchoolProject.Models;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface IuserRepository
    {
        ApplicationUser Edit(string ID, UserDto newuser);
    }
}