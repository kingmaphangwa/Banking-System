using System.ComponentModel.DataAnnotations;

namespace BankFrontEnd.EditForm
{
    public class ClientEdit
    {
        [Required(ErrorMessage = "firstname is Required")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "lastname is Required")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "date of birth is Required")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "id number is Required")]
        public string? IdNumber { get; set; }

        [Required(ErrorMessage = "address is Required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "mobile is Required")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}
