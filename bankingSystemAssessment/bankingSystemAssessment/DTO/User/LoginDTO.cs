using System.ComponentModel.DataAnnotations;

namespace bankingSystemAssessment.DTO.User
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is Required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public required string Password { get; set; }
    }
}
