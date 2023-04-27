using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LINQ_HighSchool4.Data.Migrations
{
    /// <inheritdoc />
    public partial class tableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_FK_ClassId",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false),
                    FK_CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassCourses_Classes_FK_ClassId",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassCourses_Courses_FK_CourseId",
                        column: x => x.FK_CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersClassCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_TeacherId = table.Column<int>(type: "int", nullable: false),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false),
                    FK_CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersClassCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersClassCourses_Classes_FK_ClassId",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersClassCourses_Courses_FK_CourseId",
                        column: x => x.FK_CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersClassCourses_Teachers_FK_TeacherId",
                        column: x => x.FK_TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_TeacherId = table.Column<int>(type: "int", nullable: false),
                    FK_CourseId = table.Column<int>(type: "int", nullable: false),
                    TeachersTeacherID = table.Column<int>(type: "int", nullable: true),
                    CoursesCourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersCourses_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_TeachersCourses_Teachers_TeachersTeacherID",
                        column: x => x.TeachersTeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassCourses_FK_ClassId",
                table: "ClassCourses",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassCourses_FK_CourseId",
                table: "ClassCourses",
                column: "FK_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_ClassId",
                table: "Students",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersClassCourses_FK_ClassId",
                table: "TeachersClassCourses",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersClassCourses_FK_CourseId",
                table: "TeachersClassCourses",
                column: "FK_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersClassCourses_FK_TeacherId",
                table: "TeachersClassCourses",
                column: "FK_TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersCourses_CoursesCourseId",
                table: "TeachersCourses",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersCourses_TeachersTeacherID",
                table: "TeachersCourses",
                column: "TeachersTeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeachersClassCourses");

            migrationBuilder.DropTable(
                name: "TeachersCourses");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
