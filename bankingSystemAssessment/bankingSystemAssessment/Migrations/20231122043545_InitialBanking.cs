using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bankingSystemAssessment.Migrations
{
    /// <inheritdoc />
    public partial class InitialBanking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "Date", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "391cf12f-6070-468f-983f-724de71daeee", "cheque" },
                    { "c63e4953-41cd-4392-a1c6-ae1b52c502f8", "fixed deposit" },
                    { "f999228b-41e8-44ad-a840-c13776322555", "savings" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Dob", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("63efe73a-9256-447f-b88b-c27c4d7c307f"), "johanesburg rose st 232", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), "mnn@gmail.com", "elvice", "8903473452", "doyi", "0734538499", "2" },
                    { new Guid("6920f233-6a47-4b9a-afa9-7d708d143dc9"), "johanesburg rose st 232", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), "mn@gmail.com", "john", "9903473452", "maya", "0734564499", "1" },
                    { new Guid("f58c83bf-cc65-402c-8d44-2dbc0d3fefa3"), "Pretoria rose st 232", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), "mnnn@gmail.com", "maria", "9603473452", "kaya", "0734577499", "3" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Number", "Balance", "Status", "TypeId", "UserId" },
                values: new object[,]
                {
                    { "11111111111", 0.0, "active", "f999228b-41e8-44ad-a840-c13776322555", "1" },
                    { "11111111112", 0.0, "active", "f999228b-41e8-44ad-a840-c13776322555", "1" },
                    { "11111111113", 0.0, "active", "f999228b-41e8-44ad-a840-c13776322555", "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TypeId",
                table: "Accounts",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Transections");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
