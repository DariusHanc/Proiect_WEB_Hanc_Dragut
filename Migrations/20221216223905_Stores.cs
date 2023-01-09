using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Dragut_Hanc.Migrations
{
    public partial class Stores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreID",
                table: "Product",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store_StoreID",
                table: "Product",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store_StoreID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Product_StoreID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Product");
        }
    }
}
