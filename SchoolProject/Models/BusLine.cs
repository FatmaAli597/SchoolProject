using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class BusLine
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The line name is Required")]
        [MinLength(3, ErrorMessage = "Min length of line name  must be more then 3 char")]
        public string LineName  { get; set; }
        public string address { get; set; }
        public virtual List<Bus> Buses { get; set; }
        public virtual List<BusRegon> BusRegions { get; set; }

    }
}
