using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("Visitior")]
    public class Visitior :ApplicationUser
    {
        
        //public int ID { get; set; }
     
        ////public string School_Name { get; set; }
        //public string Gender { get; set; }
        
        //[ForeignKey("receptionist")]
        //public int receptionistID { get; set; }
        //public virtual Receptionist receptionist { get; set; }
        public virtual List<VistorHitory> VistorHitories { get; set; }

        

    }
}
