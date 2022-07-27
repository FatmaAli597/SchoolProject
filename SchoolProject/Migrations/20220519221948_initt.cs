using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeadManager_Buss_HeadManagerebusId",
                table: "HeadManager");

            migrationBuilder.AlterColumn<int>(
                name: "HeadManagerebusId",
                table: "HeadManager",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HeadManager_Buss_HeadManagerebusId",
                table: "HeadManager",
                column: "HeadManagerebusId",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeadManager_Buss_HeadManagerebusId",
                table: "HeadManager");

            migrationBuilder.AlterColumn<int>(
                name: "HeadManagerebusId",
                table: "HeadManager",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HeadManager_Buss_HeadManagerebusId",
                table: "HeadManager",
                column: "HeadManagerebusId",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
