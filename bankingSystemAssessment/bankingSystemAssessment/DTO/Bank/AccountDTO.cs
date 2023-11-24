using bankingSystemAssessment.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace bankingSystemAssessment.DTO.Bank
{
    public class AccountDTO
    {
        public required string Type { get; set; }
        public required string UserId { get; set; }
    }
}
