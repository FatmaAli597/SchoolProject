
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Address { get; set; }
        public string Image { get; set; }
     
        public string SSN { get; set; }

        public string Gender { get; set; }
       
    }
}
