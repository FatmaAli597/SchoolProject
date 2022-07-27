using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class add1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "examSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Level_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_examSchedules_Levels_Level_ID",
                        column: x => x.Level_ID,
                        principalTable: "Levels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "examScheduleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Course_ID = table.Column<int>(type: "int", nullable: true),
                    ExamSchedule_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examScheduleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_examScheduleDetails_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_examScheduleDetails_examSchedules_ExamSchedule_ID",
                        column: x => x.ExamSchedule_ID,
                        principalTable: "examSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_examScheduleDetails_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_examScheduleDetails_Course_ID",
                table: "examScheduleDetails",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_examScheduleDetails_ExamSchedule_ID",
                table: "examScheduleDetails",
                column: "ExamSchedule_ID");

            migrationBuilder.CreateIndex(
                name: "IX_examScheduleDetails_TeacherID",
                table: "examScheduleDetails",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_examSchedules_Level_ID",
                table: "examSchedules",
                column: "Level_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "examScheduleDetails");

            migrationBuilder.DropTable(
                name: "examSchedules");
        }
    }
}
