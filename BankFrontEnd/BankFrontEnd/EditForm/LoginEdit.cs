using System.ComponentModel.DataAnnotations;

namespace BankFrontEnd.EditForm
{
    public class LoginEdit
    {
        [Required]
        [StringLength(9, ErrorMessage = "Username is too short")]
        public string? Username { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Username is too short")]
        public string? Pin { get; set; }
    }
}
