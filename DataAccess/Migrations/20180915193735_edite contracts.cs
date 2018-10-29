using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class editecontracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Contracts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Contracts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntitiesId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ContractsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DepartamentId",
                table: "Contracts",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EntitiesId",
                table: "Contracts",
                column: "EntitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ResponsibleId",
                table: "Contracts",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ContractsId",
                table: "Attachments",
                column: "ContractsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Departament_DepartamentId",
                table: "Contracts",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Entitys_EntitiesId",
                table: "Contracts",
                column: "EntitiesId",
                principalTable: "Entitys",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Departament_DepartamentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Entitys_EntitiesId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employee_ResponsibleId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_DepartamentId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_EntitiesId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ResponsibleId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EntitiesId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Contracts");
        }
    }
}
