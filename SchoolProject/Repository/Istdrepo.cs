using SchoolProject.Dtos;
using SchoolProject.Models;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface Istdrepo
    {
        Task<ApplicationUser> GetByemail(string email);
        public Class StudentClass(int classId);
        Student EditStd(string ID, UserDto newStd);
        }
    }