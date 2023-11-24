﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bankingSystemAssessment.Context;

#nullable disable

namespace bankingSystemAssessment.Migrations
{
    [DbContext(typeof(BankingContext))]
    [Migration("20231122043545_InitialBanking")]
    partial class InitialBanking
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bankingSystemAssessment.Models.Bank.Account", b =>
                {
                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("TypeId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Number = "11111111111",
                            Balance = 0.0,
                            Status = "active",
                            TypeId = "f999228b-41e8-44ad-a840-c13776322555",
                            UserId = "1"
                        },
                        new
                        {
                            Number = "11111111112",
                            Balance = 0.0,
                            Status = "active",
                            TypeId = "f999228b-41e8-44ad-a840-c13776322555",
                            UserId = "1"
                        },
                        new
                        {
                            Number = "11111111113",
                            Balance = 0.0,
                            Status = "active",
                            TypeId = "f999228b-41e8-44ad-a840-c13776322555",
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("bankingSystemAssessment.Models.Bank.AccountType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            Id = "f999228b-41e8-44ad-a840-c13776322555",
                            Name = "savings"
                        },
                        new
                        {
                            Id = "c63e4953-41cd-4392-a1c6-ae1b52c502f8",
                            Name = "fixed deposit"
                        },
                        new
                        {
                            Id = "391cf12f-6070-468f-983f-724de71daeee",
                            Name = "cheque"
                        });
                });

            modelBuilder.Entity("bankingSystemAssessment.Models.Bank.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6920f233-6a47-4b9a-afa9-7d708d143dc9"),
                            Address = "johanesburg rose st 232",
                            Dob = new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "mn@gmail.com",
                            FirstName = "john",
                            IdNumber = "9903473452",
                            LastName = "maya",
                            MobileNumber = "0734564499",
                            UserId = "1"
                        },
                        new
                        {
                            Id = new Guid("63efe73a-9256-447f-b88b-c27c4d7c307f"),
                            Address = "johanesburg rose st 232",
                            Dob = new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "mnn@gmail.com",
                            FirstName = "elvice",
                            IdNumber = "8903473452",
                            LastName = "doyi",
                            MobileNumber = "0734538499",
                            UserId = "2"
                        },
                        new
                        {
                            Id = new Guid("f58c83bf-cc65-402c-8d44-2dbc0d3fefa3"),
                            Address = "Pretoria rose st 232",
                            Dob = new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "mnnn@gmail.com",
                            FirstName = "maria",
                            IdNumber = "9603473452",
                            LastName = "kaya",
                            MobileNumber = "0734577499",
                            UserId = "3"
                        });
                });

            modelBuilder.Entity("bankingSystemAssessment.Models.Bank.Transection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transections");
                });

            modelBuilder.Entity("bankingSystemAssessment.Models.Bank.Account", b =>
                {
                    b.HasOne("bankingSystemAssessment.Models.Bank.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("bankingSystemAssessment.Models.Bank.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
