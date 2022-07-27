using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Start Quiz Time is Required")]
        public DateTime StartQuizime { get; set; }

        [Required(ErrorMessage = "The End Quiz Time is Required")]
        public DateTime EndQuizTime { get; set; }
        [ForeignKey("course")]
        public int? courseId { get; set; }
        public virtual Course course { get; set; }  
        public virtual List<Class> Classes { get; set; }
    }
}

