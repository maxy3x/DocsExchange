using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class correctedcontractandeployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Entities_EntitiesId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.RenameColumn(
                name: "EntitiesId",
                table: "Contracts",
                newName: "PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_EntitiesId",
                table: "Contracts",
                newName: "IX_Contracts_PartnerId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OkpoCode",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Company_PartnerId",
                table: "Contracts",
                column: "PartnerId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Company_PartnerId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OkpoCode",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "Contracts",
                newName: "EntitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_PartnerId",
                table: "Contracts",
                newName: "IX_Contracts_EntitiesId");

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Entities_EntitiesId",
                table: "Contracts",
                column: "EntitiesId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
