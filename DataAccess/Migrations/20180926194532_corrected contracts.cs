using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class correctedcontracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Company_CompanyId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Departament_DepartamentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Company_PartnerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employee_ResponsibleId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_DepartamentId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_PartnerId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ResponsibleId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ResponsibleId",
                table: "Contracts",
                newName: "Responsible");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "Contracts",
                newName: "Partner");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Contracts",
                newName: "Departament");

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Contracts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Responsible",
                table: "Contracts",
                newName: "ResponsibleId");

            migrationBuilder.RenameColumn(
                name: "Partner",
                table: "Contracts",
                newName: "PartnerId");

            migrationBuilder.RenameColumn(
                name: "Departament",
                table: "Contracts",
                newName: "DepartamentId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DepartamentId",
                table: "Contracts",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PartnerId",
                table: "Contracts",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ResponsibleId",
                table: "Contracts",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Company_CompanyId",
                table: "Contracts",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Departament_DepartamentId",
                table: "Contracts",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Company_PartnerId",
                table: "Contracts",
                column: "PartnerId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employee_ResponsibleId",
                table: "Contracts",
                column: "ResponsibleId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
