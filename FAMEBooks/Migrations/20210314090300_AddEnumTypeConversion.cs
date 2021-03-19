using Microsoft.EntityFrameworkCore.Migrations;

namespace FAMEBooks.Migrations
{
    public partial class AddEnumTypeConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
