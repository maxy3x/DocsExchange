using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Entitys_EntitiesId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entitys",
                table: "Entitys");

            migrationBuilder.RenameTable(
                name: "Entitys",
                newName: "Entities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Entities_EntitiesId",
                table: "Contracts",
                column: "EntitiesId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Entities_EntitiesId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "Entitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entitys",
                table: "Entitys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Entitys_EntitiesId",
                table: "Contracts",
                column: "EntitiesId",
                principalTable: "Entitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
