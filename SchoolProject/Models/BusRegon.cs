using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class BusRegon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Regon Name is Required")]
        [MinLength(3, ErrorMessage = "Min Length Regon Name must be more then 3 char")]
        public string RegonName { get; set; }
        public string address { get; set; }

        public virtual List<Bus> Buses { get; set; }

    }
}
