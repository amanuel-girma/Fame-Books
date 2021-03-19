using Microsoft.EntityFrameworkCore.Migrations;

namespace FAMEBooks.Migrations
{
    public partial class addBorrowStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowStatus",
                table: "Loans",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowStatus",
                table: "Loans");
        }
    }
}
