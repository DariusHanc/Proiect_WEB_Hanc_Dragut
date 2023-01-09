using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Dragut_Hanc.Migrations
{
    public partial class AvailabilityDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishingDate",
                table: "Product",
                newName: "AvailabilityDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailabilityDate",
                table: "Product",
                newName: "PublishingDate");
        }
    }
}
