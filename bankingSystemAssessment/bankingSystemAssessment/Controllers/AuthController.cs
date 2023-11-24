using bankingSystemAssessment.Context;
using bankingSystemAssessment.DTO.User;
using bankingSystemAssessment.Models.Bank;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace bankingSystemAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private BankingContext _bankingContext;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, BankingContext bankingContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _bankingContext = bankingContext;
        }

        //Route for seeding roles
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole("user"));

            return Ok("roles created");
        }

        //Route for seeding roles
        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClient([FromBody] ClientDTO client)
        {
            Random random = new Random();

            IdentityUser user = new()
            {
                Email = client.Email,
                UserName = "10" + random.Next(100000000,999999999),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var userExist = await _userManager.FindByNameAsync(user.UserName);
            if (userExist != null)
            {
                return BadRequest("User already exist");
            }

            var createUser = await _userManager.CreateAsync(user, client.Password);

            if (!createUser.Succeeded) {
                var errorString = "Failed to register user because: ";

                foreach (var error in createUser.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return BadRequest(errorString);
            }

            Client cli = new()
            {
                Id = Guid.NewGuid(),
                FirstName = client.Firstname,
                LastName = client.Lastname,
                Dob = client.Dob,
                IdNumber = client.IdNumber,
                Address = client.Address,
                MobileNumber = client.MobileNumber,
                Email = client.Email,
                UserId = user.Id
            };
            await _bankingContext.Clients.AddAsync(cli);
            var newClient = _bankingContext.SaveChanges();

            Account acc = new()
            {
                Number = user.UserName,
                TypeId = "1",
                Status = "Active",
                Balance = 0.00,
                UserId = user.Id

            };
            await _bankingContext.Accounts.AddAsync(acc);
            _bankingContext.SaveChanges();

            return Ok("Client created successfully");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                return Unauthorized("Invalid use credentials");
            }

            var correctPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if(!correctPassword)
                return Unauthorized("Invalid Credentials");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString())
            };

            foreach(var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var token = GenerateNewJwtToken(authClaims);

            return Ok(token);
        }

        private string GenerateNewJwtToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var tokenObject = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudiance"],
                expires: DateTime.Now.AddMinutes(30),
                claims: claims,
                signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }
    }
}
