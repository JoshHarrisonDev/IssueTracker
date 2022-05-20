using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracker.Data.Migrations
{
    public partial class AddassignedPersontoIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedToID",
                table: "Issue",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Progress",
                table: "Issue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issue_AssignedToID",
                table: "Issue",
                column: "AssignedToID");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Person_AssignedToID",
                table: "Issue",
                column: "AssignedToID",
                principalTable: "Person",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Person_AssignedToID",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_AssignedToID",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "AssignedToID",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Issue");
        }
    }
}
