using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {   

        // good practice to handle the validation in DTO level
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}