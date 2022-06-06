using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPITask.DAL.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressRank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "Id", "Address", "AddressRank", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("f138a31e-3c81-481e-92de-d873d020b000"), "Cairo - Egypt", 2, new Guid("f138a31e-3c81-481e-92de-d873d020b4d4") },
                    { new Guid("f138a31e-3c81-481e-92de-d873d020b111"), "Alex - Egypt", 1, new Guid("f138a31e-3c81-481e-92de-d873d020b4d4") },
                    { new Guid("f138a31e-3c81-481e-92de-d873d020b222"), "Liverpool - England", 1, new Guid("f138a31e-3c81-481e-92de-d873d020b4d5") }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { new Guid("f138a31e-3c81-481e-92de-d873d020b4d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1964), "ahmadsabry28@gmail.com", "Ahmed", "M", "Sabry" },
                    { new Guid("f138a31e-3c81-481e-92de-d873d020b4d5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1971), "mohamedsalah@gmail.com", "Mohamed", "M", "Salah" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
