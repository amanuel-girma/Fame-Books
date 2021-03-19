using Microsoft.EntityFrameworkCore.Migrations;

namespace FAMEBooks.Migrations
{
    public partial class AddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CreatedByUserId",
                table: "Books",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UpdatedByUserId",
                table: "Books",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_CreatedByUserId",
                table: "Books",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UpdatedByUserId",
                table: "Books",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_CreatedByUserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UpdatedByUserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CreatedByUserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UpdatedByUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Books");
        }
    }
}
