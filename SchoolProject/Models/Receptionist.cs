using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("Receptionist")]
    public class Receptionist:ApplicationUser
    {
       

        //[ForeignKey("busReceptionist")]
        //public int? busReceptionistID { get; set; }
        //public virtual Bus busReceptionist { get; set; }     
        public virtual List<Visitior> visitiors { get; set; }
        public virtual List<StaffAttentance> staffAttentances { get; set; }

    }
}
