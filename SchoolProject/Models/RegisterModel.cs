using System.ComponentModel.DataAnnotations;

namespace TestApiJWT.Models
{
    public class RegisterModel
    {
        [Required]
        public string Address { get; set; }
        public string Image { get; set; }
        [Required , StringLength(14)]
        public string SSN { get; set; }
        [Required, StringLength(20)]
        public string Gender { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }



    }
}