using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusLines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusRegons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusLineID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRegons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusRegons_BusLines_BusLineID",
                        column: x => x.BusLineID,
                        principalTable: "BusLines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "BusAdmin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    BusDriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BusChairNumber = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusLineID = table.Column<int>(type: "int", nullable: true),
                    BusAdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusRegonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buss_BusAdmin_BusAdminId",
                        column: x => x.BusAdminId,
                        principalTable: "BusAdmin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buss_BusLines_BusLineID",
                        column: x => x.BusLineID,
                        principalTable: "BusLines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buss_BusRegons_BusRegonID",
                        column: x => x.BusRegonID,
                        principalTable: "BusRegons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Buss_BusID",
                        column: x => x.BusID,
                        principalTable: "Buss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadManager",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HeadManagerebusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadManager_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadManager_Buss_HeadManagerebusId",
                        column: x => x.HeadManagerebusId,
                        principalTable: "Buss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManagerbusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manager_Buss_ManagerbusId",
                        column: x => x.ManagerbusId,
                        principalTable: "Buss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TuitionExpenses = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parent_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionist_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    busTeacherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_Buss_busTeacherID",
                        column: x => x.busTeacherID,
                        principalTable: "Buss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitior",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceptionistId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitior", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitior_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitior_Receptionist_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Receptionist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffAttentances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isabsent = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HeadManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceptionistId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAttentances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StaffAttentances_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAttentances_HeadManager_HeadManagerId",
                        column: x => x.HeadManagerId,
                        principalTable: "HeadManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAttentances_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAttentances_Receptionist_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Receptionist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAttentances_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vistorHitories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visit_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitiorReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VisitiorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistorHitories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vistorHitories_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vistorHitories_Visitior_VisitiorId",
                        column: x => x.VisitiorId,
                        principalTable: "Visitior",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "courseScheduleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: true),
                    CourseSchedule_ID = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseScheduleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseScheduleDetails_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historyOfStudends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LevelID = table.Column<int>(type: "int", nullable: true),
                    StudyYearID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historyOfStudends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_historyOfStudends_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    HistoryOfStudendID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Levels_historyOfStudends_HistoryOfStudendID",
                        column: x => x.HistoryOfStudendID,
                        principalTable: "historyOfStudends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_StudyYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_StudyYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HistoryOfStudendID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyYears_historyOfStudends_HistoryOfStudendID",
                        column: x => x.HistoryOfStudendID,
                        principalTable: "historyOfStudends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChairNumber = table.Column<int>(type: "int", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classes_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeacher",
                columns: table => new
                {
                    ClassesID = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacher", x => new { x.ClassesID, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Classes_ClassesID",
                        column: x => x.ClassesID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courseSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Level_ID = table.Column<int>(type: "int", nullable: true),
                    Class_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseSchedules_Classes_Class_ID",
                        column: x => x.Class_ID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courseSchedules_Levels_Level_ID",
                        column: x => x.Level_ID,
                        principalTable: "Levels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Holiday = table.Column<int>(type: "int", nullable: false),
                    AbsenceDays = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    busStudentID = table.Column<int>(type: "int", nullable: false),
                    classId = table.Column<int>(type: "int", nullable: true),
                    LevelID = table.Column<int>(type: "int", nullable: true),
                    counterForLevel = table.Column<int>(type: "int", nullable: false),
                    studyYearID = table.Column<int>(type: "int", nullable: true),
                    HistoryOfStudendID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Buss_busStudentID",
                        column: x => x.busStudentID,
                        principalTable: "Buss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Classes_classId",
                        column: x => x.classId,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_historyOfStudends_HistoryOfStudendID",
                        column: x => x.HistoryOfStudendID,
                        principalTable: "historyOfStudends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_StudyYears_studyYearID",
                        column: x => x.studyYearID,
                        principalTable: "StudyYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    TeachersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    coursesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.TeachersId, x.coursesID });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_coursesID",
                        column: x => x.coursesID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartQuizime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndQuizTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExamTables_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttentances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isabsent = table.Column<bool>(type: "bit", nullable: false),
                    studentAttendanceID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttentances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentAttentances_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAttentances_Student_studentAttendanceID",
                        column: x => x.studentAttendanceID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassQuiz",
                columns: table => new
                {
                    ClassesID = table.Column<int>(type: "int", nullable: false),
                    QuizsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassQuiz", x => new { x.ClassesID, x.QuizsID });
                    table.ForeignKey(
                        name: "FK_ClassQuiz_Classes_ClassesID",
                        column: x => x.ClassesID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassQuiz_ExamTables_QuizsID",
                        column: x => x.QuizsID,
                        principalTable: "ExamTables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusID",
                table: "AspNetUsers",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BusRegons_BusLineID",
                table: "BusRegons",
                column: "BusLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Buss_ApplicationUserID",
                table: "Buss",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Buss_BusAdminId",
                table: "Buss",
                column: "BusAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Buss_BusLineID",
                table: "Buss",
                column: "BusLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Buss_BusRegonID",
                table: "Buss",
                column: "BusRegonID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LevelID",
                table: "Classes",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassQuiz_QuizsID",
                table: "ClassQuiz",
                column: "QuizsID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_TeachersId",
                table: "ClassTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelID",
                table: "Courses",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_courseScheduleDetails_ApplicationUserID",
                table: "courseScheduleDetails",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_courseScheduleDetails_Course_ID",
                table: "courseScheduleDetails",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_courseScheduleDetails_CourseSchedule_ID",
                table: "courseScheduleDetails",
                column: "CourseSchedule_ID");

            migrationBuilder.CreateIndex(
                name: "IX_courseSchedules_Class_ID",
                table: "courseSchedules",
                column: "Class_ID");

            migrationBuilder.CreateIndex(
                name: "IX_courseSchedules_Level_ID",
                table: "courseSchedules",
                column: "Level_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_coursesID",
                table: "CourseTeacher",
                column: "coursesID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTables_courseId",
                table: "ExamTables",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadManager_HeadManagerebusId",
                table: "HeadManager",
                column: "HeadManagerebusId");

            migrationBuilder.CreateIndex(
                name: "IX_historyOfStudends_ApplicationUserID",
                table: "historyOfStudends",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_historyOfStudends_LevelID",
                table: "historyOfStudends",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_historyOfStudends_StudyYearID",
                table: "historyOfStudends",
                column: "StudyYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_HistoryOfStudendID",
                table: "Levels",
                column: "HistoryOfStudendID");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerbusId",
                table: "Manager",
                column: "ManagerbusId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttentances_ApplicationUserID",
                table: "StaffAttentances",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttentances_HeadManagerId",
                table: "StaffAttentances",
                column: "HeadManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttentances_ManagerId",
                table: "StaffAttentances",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttentances_ReceptionistId",
                table: "StaffAttentances",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttentances_TeacherId",
                table: "StaffAttentances",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_busStudentID",
                table: "Student",
                column: "busStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_classId",
                table: "Student",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_HistoryOfStudendID",
                table: "Student",
                column: "HistoryOfStudendID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_LevelID",
                table: "Student",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ParentID",
                table: "Student",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_studyYearID",
                table: "Student",
                column: "studyYearID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttentances_ClassID",
                table: "StudentAttentances",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttentances_studentAttendanceID",
                table: "StudentAttentances",
                column: "studentAttendanceID");

            migrationBuilder.CreateIndex(
                name: "IX_StudyYears_HistoryOfStudendID",
                table: "StudyYears",
                column: "HistoryOfStudendID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_busTeacherID",
                table: "Teacher",
                column: "busTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitior_ReceptionistId",
                table: "Visitior",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_vistorHitories_ApplicationUserID",
                table: "vistorHitories",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_vistorHitories_VisitiorId",
                table: "vistorHitories",
                column: "VisitiorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusAdmin_AspNetUsers_Id",
                table: "BusAdmin",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buss_AspNetUsers_ApplicationUserID",
                table: "Buss",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_courseScheduleDetails_Courses_Course_ID",
                table: "courseScheduleDetails",
                column: "Course_ID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_courseScheduleDetails_courseSchedules_CourseSchedule_ID",
                table: "courseScheduleDetails",
                column: "CourseSchedule_ID",
                principalTable: "courseSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_historyOfStudends_Levels_LevelID",
                table: "historyOfStudends",
                column: "LevelID",
                principalTable: "Levels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_historyOfStudends_StudyYears_StudyYearID",
                table: "historyOfStudends",
                column: "StudyYearID",
                principalTable: "StudyYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusAdmin_AspNetUsers_Id",
                table: "BusAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Buss_AspNetUsers_ApplicationUserID",
                table: "Buss");

            migrationBuilder.DropForeignKey(
                name: "FK_historyOfStudends_AspNetUsers_ApplicationUserID",
                table: "historyOfStudends");

            migrationBuilder.DropForeignKey(
                name: "FK_historyOfStudends_Levels_LevelID",
                table: "historyOfStudends");

            migrationBuilder.DropForeignKey(
                name: "FK_historyOfStudends_StudyYears_StudyYearID",
                table: "historyOfStudends");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClassQuiz");

            migrationBuilder.DropTable(
                name: "ClassTeacher");

            migrationBuilder.DropTable(
                name: "courseScheduleDetails");

            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "StaffAttentances");

            migrationBuilder.DropTable(
                name: "StudentAttentances");

            migrationBuilder.DropTable(
                name: "vistorHitories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExamTables");

            migrationBuilder.DropTable(
                name: "courseSchedules");

            migrationBuilder.DropTable(
                name: "HeadManager");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Visitior");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Buss");

            migrationBuilder.DropTable(
                name: "BusAdmin");

            migrationBuilder.DropTable(
                name: "BusRegons");

            migrationBuilder.DropTable(
                name: "BusLines");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "StudyYears");

            migrationBuilder.DropTable(
                name: "historyOfStudends");
        }
    }
}
