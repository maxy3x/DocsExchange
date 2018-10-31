using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class correctedFilesContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Contracts_ContractsId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_ContractsId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ContractsId",
                table: "Attachments");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentsId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AttachmentsId",
                table: "Contracts",
                column: "AttachmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Attachments_AttachmentsId",
                table: "Contracts",
                column: "AttachmentsId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Attachments_AttachmentsId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_AttachmentsId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "AttachmentsId",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "ContractsId",
                table: "Attachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ContractsId",
                table: "Attachments",
                column: "ContractsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Contracts_ContractsId",
                table: "Attachments",
                column: "ContractsId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
