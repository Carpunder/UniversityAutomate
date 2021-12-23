using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityAutomate.Migrations
{
    public partial class AddUniqueConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniversityName",
                table: "Universities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_UniversityName",
                table: "Universities",
                column: "UniversityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentName",
                table: "Students",
                column: "StudentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupName_UniversityID",
                table: "Groups",
                columns: new[] { "GroupName", "UniversityID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityName",
                table: "Cities",
                column: "CityName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Universities_UniversityName",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupName_UniversityID",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityName",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "UniversityName",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
