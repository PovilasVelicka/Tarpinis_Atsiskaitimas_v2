using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.DAL.Migrations
{
    public partial class CreateDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "InfoSystem");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "InfoSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                schema: "InfoSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "InfoSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "InfoSystem",
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLecture",
                schema: "InfoSystem",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "int", nullable: false),
                    LecturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLecture", x => new { x.DepartmentsId, x.LecturesId });
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalSchema: "InfoSystem",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Lectures_LecturesId",
                        column: x => x.LecturesId,
                        principalSchema: "InfoSystem",
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureStudent",
                schema: "InfoSystem",
                columns: table => new
                {
                    LecturesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureStudent", x => new { x.LecturesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LectureStudent_Lectures_LecturesId",
                        column: x => x.LecturesId,
                        principalSchema: "InfoSystem",
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "InfoSystem",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLecture_LecturesId",
                schema: "InfoSystem",
                table: "DepartmentLecture",
                column: "LecturesId");

            migrationBuilder.CreateIndex(
                name: "UX_Lecture_Title",
                schema: "InfoSystem",
                table: "Lectures",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudent_StudentsId",
                schema: "InfoSystem",
                table: "LectureStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                schema: "InfoSystem",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UX_Students_PersonalCode",
                schema: "InfoSystem",
                table: "Students",
                column: "PersonalCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLecture",
                schema: "InfoSystem");

            migrationBuilder.DropTable(
                name: "LectureStudent",
                schema: "InfoSystem");

            migrationBuilder.DropTable(
                name: "Lectures",
                schema: "InfoSystem");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "InfoSystem");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "InfoSystem");
        }
    }
}
