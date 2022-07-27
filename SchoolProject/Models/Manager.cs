using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("Manager")]
    public class Manager :ApplicationUser
    {


        [ForeignKey("Managerbus")]
        public int? ManagerbusId { get; set; }
        public virtual Bus Managerbus { get; set; }
        public virtual List<StaffAttentance> staffAttentances { get; set; }







    }
}
