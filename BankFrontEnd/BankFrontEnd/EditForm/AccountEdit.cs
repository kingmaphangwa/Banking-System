using System.ComponentModel.DataAnnotations;

namespace BankFrontEnd.EditForm
{
    public class AccountEdit
    {
        [Required(ErrorMessage = "Account type is Required")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        public string? UserId { get; set; }
    }
}
