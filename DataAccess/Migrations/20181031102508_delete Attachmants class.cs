using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class deleteAttachmantsclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Attachments_AttachmentsId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_AttachmentsId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "AttachmentsId",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Contracts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentsId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

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
    }
}
