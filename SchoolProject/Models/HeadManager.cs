using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    [Table("HeadManager")]
    public class HeadManager:ApplicationUser
    {

        [ForeignKey("HeadManagerebus")]
        public int? HeadManagerebusId { get; set; }
        public virtual Bus HeadManagerebus { get; set; }
        public virtual List<StaffAttentance> staffAttentances { get; set; }
      



    }
}
