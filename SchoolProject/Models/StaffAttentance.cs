using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class StaffAttentance
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "The Time is Required")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "The Staff absent is Required")]
        
        public bool Isabsent { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("busAdmin")]
        //public int? busAdminID { get; set; }
        //public virtual BusAdmin busAdmin { get; set; }


        //[ForeignKey("teacher")]
        //public int? teacherID { get; set; }
        //public virtual Teacher teacher { get; set; }


        //[ForeignKey("headManager")]
        //public int? headManagerID { get; set; }
        //public virtual HeadManager headManager { get; set; }

        //[ForeignKey("manager")]
        //public int? managerID { get; set; }
        //public virtual Manager manager { get; set; }

        //[ForeignKey("receptionist")]
        //public int? receptionistID { get; set; }
        //public virtual Receptionist receptionist { get; set; }



    }
}
