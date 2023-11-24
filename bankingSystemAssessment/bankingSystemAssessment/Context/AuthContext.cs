using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace bankingSystemAssessment.Context
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser {
                Id = "1",
                UserName = "11111111111",
                NormalizedUserName = "11111111111",
                Email = "mn@gmail.com",
                NormalizedEmail = "mn@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "12345"),
                SecurityStamp = Guid.NewGuid().ToString()
                },

                new IdentityUser
                {
                    Id = "2",
                    UserName = "11111111112",
                    NormalizedUserName = "11111111112",
                    Email = "mnn@gmail.com",
                    NormalizedEmail = "mnn@gmail.com",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new IdentityUser
                {
                    Id = "3",
                    UserName = "11111111113",
                    NormalizedUserName = "11111111113",
                    Email = "mnnn@gmail.com",
                    NormalizedEmail = "mnnn@gmail.com",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
                );
        }
    }
}
