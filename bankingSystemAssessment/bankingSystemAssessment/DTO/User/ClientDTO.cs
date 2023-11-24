using System.ComponentModel.DataAnnotations;

namespace bankingSystemAssessment.DTO.User
{
    public class ClientDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "firstname is Required")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "lastname is Required")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "date of birth is Required")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "id number is Required")]
        public required string IdNumber { get; set; }

        [Required(ErrorMessage = "address is Required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "mobile is Required")]
        public required string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public required string Password { get; set; }
    }
}
