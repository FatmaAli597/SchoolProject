using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("BusAdmin")]
    public class BusAdmin :ApplicationUser
    {
     
        //public int Id { get; set; }

        // public string Image { get; set; }
        public virtual List<Bus> Buses { get; set; }
        //[ForeignKey("bus")]
        //public int BusID { get; set; }
        //public virtual Bus bus { get; set; }
        //public virtual List<StaffAttentance> staffAttentances { get; set; }
        //public string ApplicationUserID { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
