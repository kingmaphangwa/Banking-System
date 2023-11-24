using bankingSystemAssessment.Context;
using bankingSystemAssessment.DTO.Bank;
using bankingSystemAssessment.Models.Bank;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bankingSystemAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BalanceController : ControllerBase
    {
        BankingContext _bankingContext;
        public BalanceController(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

        [HttpPut]
        [Route("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] BallanceDTO withdraw)
        {
            var getA = await _bankingContext.Accounts.FindAsync(withdraw.AccountNumber);
            double ballance = getA.Balance;
            if (getA.Status != "active")
                return BadRequest("Your account is currently deactivated");

            if(withdraw.Amount <= 0)
                return BadRequest("Widrawal amoun must be greater than zero");
            
            if(withdraw.Amount > ballance)
                return BadRequest($"Insufficient funds. Available Balance: {ballance}");

            if (getA.Balance == withdraw.Amount && getA.TypeId != "fixed deposit")
                return BadRequest("Account is not allowed to withdraw 100% balance");

            getA.Balance = ballance - withdraw.Amount;

            _bankingContext.Entry(getA).State = EntityState.Modified;
            var update = await _bankingContext.SaveChangesAsync();

            Transaction transection = new()
            {
                Id = Guid.NewGuid(),
                Type = "withdraw",
                Time = DateTime.Now,
                AccountNumber = withdraw.AccountNumber,
                UserId = getA.UserId,
            };

            await _bankingContext.Transactions.AddAsync(transection);
            await _bankingContext.SaveChangesAsync();

            return  Ok(update);
        }

        [HttpPut]
        [Route("deposit")]
        public async Task<IActionResult> Deposit([FromBody] BallanceDTO deposit)
        {
            Account getA = await _bankingContext.Accounts.FindAsync(deposit.AccountNumber);
            double ballance = getA.Balance;
            if (getA.Status != "active")
                return BadRequest("Your account is currently deactivated");

            if (deposit.Amount <= 0)
                return BadRequest("Deposit amoun must be greater than zero");

            getA.Balance = ballance + deposit.Amount;

            _bankingContext.Entry(getA).State = EntityState.Modified;
            var update = await _bankingContext.SaveChangesAsync();

            Transaction transection = new()
            {
                Id = Guid.NewGuid(),
                Type = "deposit",
                Time = DateTime.Now,
                AccountNumber = deposit.AccountNumber,
                UserId = getA.UserId,
            };

            await _bankingContext.Transactions.AddAsync(transection);
            await _bankingContext.SaveChangesAsync();

            return Ok(update);
        }
    }
}
