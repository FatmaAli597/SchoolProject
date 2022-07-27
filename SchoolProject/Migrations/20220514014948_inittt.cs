using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class inittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Buss_BusID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusRegons_BusLines_BusLineID",
                table: "BusRegons");

            migrationBuilder.DropForeignKey(
                name: "FK_Buss_BusRegons_BusRegonID",
                table: "Buss");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuiz_Classes_ClassesID",
                table: "ClassQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuiz_ExamTables_QuizsID",
                table: "ClassQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeacher_Classes_ClassesID",
                table: "ClassTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Courses_coursesID",
                table: "CourseTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Levels_LevelID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttentances_Classes_ClassID",
                table: "StudentAttentances");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "StudentAttentances",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StudentAttentances",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttentances_ClassID",
                table: "StudentAttentances",
                newName: "IX_StudentAttentances_ClassId");

            migrationBuilder.RenameColumn(
                name: "LevelID",
                table: "Student",
                newName: "LevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_LevelID",
                table: "Student",
                newName: "IX_Student_LevelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StaffAttentances",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Levels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExamTables",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "coursesID",
                table: "CourseTeacher",
                newName: "coursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeacher_coursesID",
                table: "CourseTeacher",
                newName: "IX_CourseTeacher_coursesId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClassesID",
                table: "ClassTeacher",
                newName: "ClassesId");

            migrationBuilder.RenameColumn(
                name: "QuizsID",
                table: "ClassQuiz",
                newName: "QuizsId");

            migrationBuilder.RenameColumn(
                name: "ClassesID",
                table: "ClassQuiz",
                newName: "ClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassQuiz_QuizsID",
                table: "ClassQuiz",
                newName: "IX_ClassQuiz_QuizsId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Classes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BusRegonID",
                table: "Buss",
                newName: "BusRegonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Buss",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Buss_BusRegonID",
                table: "Buss",
                newName: "IX_Buss_BusRegonId");

            migrationBuilder.RenameColumn(
                name: "BusLineID",
                table: "BusRegons",
                newName: "BusLineId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BusRegons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BusRegons_BusLineID",
                table: "BusRegons",
                newName: "IX_BusRegons_BusLineId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BusLines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BusID",
                table: "AspNetUsers",
                newName: "BusId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BusID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_BusId");

            migrationBuilder.AddColumn<int>(
                name: "examScheduleDetailsID",
                table: "Levels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "courseScheduleDetailsID",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Levels_examScheduleDetailsID",
                table: "Levels",
                column: "examScheduleDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClassId",
                table: "Courses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_courseScheduleDetailsID",
                table: "Classes",
                column: "courseScheduleDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Buss_BusId",
                table: "AspNetUsers",
                column: "BusId",
                principalTable: "Buss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusRegons_BusLines_BusLineId",
                table: "BusRegons",
                column: "BusLineId",
                principalTable: "BusLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buss_BusRegons_BusRegonId",
                table: "Buss",
                column: "BusRegonId",
                principalTable: "BusRegons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_courseScheduleDetails_courseScheduleDetailsID",
                table: "Classes",
                column: "courseScheduleDetailsID",
                principalTable: "courseScheduleDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuiz_Classes_ClassesId",
                table: "ClassQuiz",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuiz_ExamTables_QuizsId",
                table: "ClassQuiz",
                column: "QuizsId",
                principalTable: "ExamTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacher_Classes_ClassesId",
                table: "ClassTeacher",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_ClassId",
                table: "Courses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Courses_coursesId",
                table: "CourseTeacher",
                column: "coursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_examScheduleDetails_examScheduleDetailsID",
                table: "Levels",
                column: "examScheduleDetailsID",
                principalTable: "examScheduleDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Levels_LevelId",
                table: "Student",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttentances_Classes_ClassId",
                table: "StudentAttentances",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Buss_BusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusRegons_BusLines_BusLineId",
                table: "BusRegons");

            migrationBuilder.DropForeignKey(
                name: "FK_Buss_BusRegons_BusRegonId",
                table: "Buss");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_courseScheduleDetails_courseScheduleDetailsID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuiz_Classes_ClassesId",
                table: "ClassQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuiz_ExamTables_QuizsId",
                table: "ClassQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeacher_Classes_ClassesId",
                table: "ClassTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_ClassId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Courses_coursesId",
                table: "CourseTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Levels_examScheduleDetails_examScheduleDetailsID",
                table: "Levels");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Levels_LevelId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttentances_Classes_ClassId",
                table: "StudentAttentances");

            migrationBuilder.DropIndex(
                name: "IX_Levels_examScheduleDetailsID",
                table: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ClassId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Classes_courseScheduleDetailsID",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "examScheduleDetailsID",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "courseScheduleDetailsID",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "StudentAttentances",
                newName: "ClassID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentAttentances",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttentances_ClassId",
                table: "StudentAttentances",
                newName: "IX_StudentAttentances_ClassID");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "Student",
                newName: "LevelID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_LevelId",
                table: "Student",
                newName: "IX_Student_LevelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StaffAttentances",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Levels",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamTables",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "coursesId",
                table: "CourseTeacher",
                newName: "coursesID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeacher_coursesId",
                table: "CourseTeacher",
                newName: "IX_CourseTeacher_coursesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "ClassTeacher",
                newName: "ClassesID");

            migrationBuilder.RenameColumn(
                name: "QuizsId",
                table: "ClassQuiz",
                newName: "QuizsID");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "ClassQuiz",
                newName: "ClassesID");

            migrationBuilder.RenameIndex(
                name: "IX_ClassQuiz_QuizsId",
                table: "ClassQuiz",
                newName: "IX_ClassQuiz_QuizsID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Classes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BusRegonId",
                table: "Buss",
                newName: "BusRegonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Buss",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Buss_BusRegonId",
                table: "Buss",
                newName: "IX_Buss_BusRegonID");

            migrationBuilder.RenameColumn(
                name: "BusLineId",
                table: "BusRegons",
                newName: "BusLineID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BusRegons",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_BusRegons_BusLineId",
                table: "BusRegons",
                newName: "IX_BusRegons_BusLineID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BusLines",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BusId",
                table: "AspNetUsers",
                newName: "BusID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BusId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_BusID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Buss_BusID",
                table: "AspNetUsers",
                column: "BusID",
                principalTable: "Buss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusRegons_BusLines_BusLineID",
                table: "BusRegons",
                column: "BusLineID",
                principalTable: "BusLines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buss_BusRegons_BusRegonID",
                table: "Buss",
                column: "BusRegonID",
                principalTable: "BusRegons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuiz_Classes_ClassesID",
                table: "ClassQuiz",
                column: "ClassesID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuiz_ExamTables_QuizsID",
                table: "ClassQuiz",
                column: "QuizsID",
                principalTable: "ExamTables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacher_Classes_ClassesID",
                table: "ClassTeacher",
                column: "ClassesID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Courses_coursesID",
                table: "CourseTeacher",
                column: "coursesID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Levels_LevelID",
                table: "Student",
                column: "LevelID",
                principalTable: "Levels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttentances_Classes_ClassID",
                table: "StudentAttentances",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
