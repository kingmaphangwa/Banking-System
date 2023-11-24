using System.ComponentModel.DataAnnotations;

namespace bankingSystemAssessment.Models.Bank
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime Time { get; set; }
        public string? AccountNumber { get; set; }
        public string? UserId { get; set; }
    }
}
