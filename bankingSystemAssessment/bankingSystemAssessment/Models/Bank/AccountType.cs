using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace bankingSystemAssessment.Models.Bank
{
    public class AccountType
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
