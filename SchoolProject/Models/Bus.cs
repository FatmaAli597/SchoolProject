using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "the BusNumber is Required")]
        [StringLength(7)]
        public string BusNumber { get; set; }
        [Required(ErrorMessage = "the Bus Driver Name is Required")]
        [MinLength(3,ErrorMessage = "Min Length of name  must be more then 3 char")]
        [MaxLength(100, ErrorMessage = "Max Length of name must be more then 3 char")]
        public string BusDriverName { get; set; }

        [Required(ErrorMessage = "the Bus Chair Number is Required")]
        public int? BusChairNumber { get; set; }

        //[ForeignKey("busAdmin")]
        //public int? AdminBusID { get; set; }
        //public virtual BusAdmin busAdmin { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("BusLine")]
        public int? BusLineID { get; set; }
        public virtual BusLine busLine { get; set; }
        public virtual List<ApplicationUser>Users { get; set; }
       
        //public virtual List<BusLine> BusLines { get; set; }

    }
}





