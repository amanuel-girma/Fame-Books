using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FAMEBooks.Migrations
{
    public partial class addColumnsLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "Loans",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowEndDate",
                table: "Loans",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BorrowEndDate",
                table: "Loans");
        }
    }
}
