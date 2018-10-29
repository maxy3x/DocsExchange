using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class editedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entitys",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Entitys",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartamentId",
                table: "Employee",
                column: "DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Departament_DepartamentId",
                table: "Employee",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Departament_DepartamentId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartamentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entitys");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Entitys");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employee");
        }
    }
}
