using bankingSystemAssessment.Context;
using bankingSystemAssessment.DTO.Bank;
using bankingSystemAssessment.Models.Bank;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bankingSystemAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private BankingContext _bankingContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(BankingContext bankingContext,
            UserManager<IdentityUser> userManager)
        {
            _bankingContext = bankingContext;
            _userManager = userManager;
        }

        // GET: api/<AccountController>
        [HttpGet]
        [Route("get-accounts")]
        public IActionResult GetAccounts()
        {
             var acc =   _bankingContext.Set<Account>().ToList();

            return Ok(acc);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> ClientAcounts(string id)
        //{
        //    var acc = await _bankingContext.Accounts.FirstAsync(e => e.UserId == id);

        //    return Ok(acc);
        //}

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Detail(string id)
        {
            var entity = await _bankingContext.Set<Account>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            var typ = await _bankingContext.Set<AccountType>().FindAsync(entity.TypeId);

            entity.AccountType = typ;

            return Ok(entity);
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("add-account")]
        public async Task<IActionResult> AddAcount([FromBody] AccountDTO accountDTO)
        {
            Random random = new Random();

            Account acc = new()
            {
                Number = "10" + random.Next(100000000, 999999999),
                TypeId = accountDTO.Type,
                Status = "Active",
                Balance = 0.00,
                UserId = accountDTO.UserId

            };
            await _bankingContext.Accounts.AddAsync(acc);
            _bankingContext.SaveChanges();

            return Ok("Account created successfully");
        }

        //// PUT api/<AccountController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AccountController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
