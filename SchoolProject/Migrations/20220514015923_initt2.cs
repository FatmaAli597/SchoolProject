using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class initt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Buss_busStudentID",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "busStudentID",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Buss_busStudentID",
                table: "Student",
                column: "busStudentID",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Buss_busStudentID",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "busStudentID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Buss_busStudentID",
                table: "Student",
                column: "busStudentID",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
