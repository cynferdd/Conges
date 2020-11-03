using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ArchiveDate = table.Column<DateTime>(nullable: true),
                    AcquisitionStartDate = table.Column<DateTime>(nullable: true),
                    AcquisitionEndDate = table.Column<DateTime>(nullable: true),
                    ConsommationStartDate = table.Column<DateTime>(nullable: true),
                    ConsommationEndDate = table.Column<DateTime>(nullable: true),
                    AmountGained = table.Column<decimal>(nullable: true),
                    Frequency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
