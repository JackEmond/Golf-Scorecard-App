using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcGolfScorecardApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scorecard_Course_CourseId",
                table: "Scorecard");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Scorecard",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scorecard_Course_CourseId",
                table: "Scorecard",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scorecard_Course_CourseId",
                table: "Scorecard");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Scorecard",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Scorecard_Course_CourseId",
                table: "Scorecard",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");
        }
    }
}
