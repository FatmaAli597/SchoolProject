using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class init24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Buss_busTeacherID",
                table: "Teacher");

            migrationBuilder.AlterColumn<int>(
                name: "busTeacherID",
                table: "Teacher",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Buss_busTeacherID",
                table: "Teacher",
                column: "busTeacherID",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Buss_busTeacherID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "role",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "busTeacherID",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Buss_busTeacherID",
                table: "Teacher",
                column: "busTeacherID",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
