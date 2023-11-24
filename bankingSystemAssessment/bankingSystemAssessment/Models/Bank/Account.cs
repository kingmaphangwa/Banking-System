using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankingSystemAssessment.Models.Bank
{
    public class Account
    {
        [Key] 
        public required string Number { get; set; }
        public required string TypeId { get; set; }
        public required string Status { get; set; }
        public double Balance { get; set; }
        public required string UserId { get; set; }

        public AccountType? AccountType { get; set; }
    }
}
