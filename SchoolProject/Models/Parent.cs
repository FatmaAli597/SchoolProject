using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("Parent")]
    public class Parent:ApplicationUser
    {
        
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      

        //المصاريف الدراسيه
        public double? TuitionExpenses {get; set; }

        public virtual List<Student> students { get; set; }
   
    }
}
