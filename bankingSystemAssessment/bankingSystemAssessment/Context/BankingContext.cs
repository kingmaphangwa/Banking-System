using bankingSystemAssessment.Models.Bank;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace bankingSystemAssessment.Context
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options): base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(e => e.AccountType)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.TypeId)
                .IsRequired();

            var accountType1 = new AccountType { Id = "1", Name = "savings" };
            var accountType2 = new AccountType { Id = "2", Name = "fixed deposit" };
            var accountType3 = new AccountType { Id = "3", Name = "cheque" };

            modelBuilder.Entity<AccountType>().HasData(accountType1, accountType2, accountType3);

            modelBuilder.Entity<Client>().HasData(
                new Client{
                    Id = Guid.NewGuid(),
                    FirstName = "john",
                    LastName = "maya",
                    Dob = DateTime.Now.Date,
                    IdNumber = "9903473452",
                    Address = "johanesburg rose st 232",
                    MobileNumber = "0734564499",
                    Email = "mn@gmail.com",
                    UserId = "1"
                },

                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "elvice",
                    LastName = "doyi",
                    Dob = DateTime.Now.Date,
                    IdNumber = "8903473452",
                    Address = "johanesburg rose st 232",
                    MobileNumber = "0734538499",
                    Email = "mnn@gmail.com",
                    UserId = "2"
                },

                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "maria",
                    LastName = "kaya",
                    Dob = DateTime.Now.Date,
                    IdNumber = "9603473452",
                    Address = "Pretoria rose st 232",
                    MobileNumber = "0734577499",
                    Email = "mnnn@gmail.com",
                    UserId = "3"
                }
                );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Number = "11111111111",
                    TypeId = accountType1.Id.ToString(),
                    Status = "active",
                    Balance = 0.00,
                    UserId = "1"
                },

                new Account
                {
                    Number = "11111111112",
                    TypeId = accountType1.Id.ToString(),
                    Status = "active",
                    Balance = 0.00,
                    UserId = "1"
                },

                new Account
                {
                    Number = "11111111113",
                    TypeId = accountType1.Id.ToString(),
                    Status = "active",
                    Balance = 0.00,
                    UserId = "1"
                }
                );
        }
    }
}
