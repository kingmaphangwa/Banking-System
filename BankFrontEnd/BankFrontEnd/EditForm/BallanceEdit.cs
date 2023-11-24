using System.ComponentModel.DataAnnotations;

namespace BankFrontEnd.EditForm
{
    public class BallanceEdit
    {
        [Required(ErrorMessage ="Account number is required")]
        public string? AccountNumber { get; set; }
        [Required(ErrorMessage = "Amount number is required")]
        [Range(0,10000000000000000000, ErrorMessage ="Invalid number")]
        public double? Amount { get; set; }
    }
}
