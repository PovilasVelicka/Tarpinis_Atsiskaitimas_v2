using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.DAL.Migrations
{
    public partial class ChangeLectureProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LectureId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "DepartmentLecture",
                newName: "LecturesId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LectureId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LecturesId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "DepartmentLecture",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LecturesId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LectureId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LectureId",
                table: "DepartmentLecture",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
