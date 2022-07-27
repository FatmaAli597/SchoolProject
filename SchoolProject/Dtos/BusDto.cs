using SchoolProject.Models;
using System.Collections.Generic;

namespace SchoolProject.Dtos
{
    public class BusDto
    {
        public int Id { get; set; }
        public string BusNumber { get; set; }
       public string BusDriverName { get; set; }
       public int BusChairNumber { get; set; }
       public string  ApplicationUserID { get; set; }
       public int BusLineID { get; set; }
       public string BusAdminId { get; set; }

       public int BusRegonID { get; set; }
       public List<ApplicationUser> Users { get; set; }

    }
}
