using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankingSystemAssessment.Models.Bank
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Dob { get; set; }
        public required string IdNumber { get; set; }
        public required string Address { get; set; }
        public required string MobileNumber { get; set; }
        public required string Email { get; set; }
        public required string UserId { get; set; }
    }
}
