using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcGolfScorecardApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoleOne = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleTwo = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleThree = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFour = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFive = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSix = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSeven = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleEight = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleNine = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleTen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleEleven = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleTwelve = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleThirteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFourteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFifteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSixteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSeventeen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleEighteen = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Scorecard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoleOne = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleTwo = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleThree = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFour = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFive = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSix = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSeven = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleEight = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleNine = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleTen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleEleven = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleTwelve = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleThirteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFourteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleFifteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSixteen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleSeventeen = table.Column<byte>(type: "tinyint", nullable: false),
                    HoleEighteen = table.Column<byte>(type: "tinyint", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scorecard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scorecard_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scorecard_CourseId",
                table: "Scorecard",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scorecard");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
