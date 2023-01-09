using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Dragut_Hanc.Migrations
{
    public partial class CreateIdentityDesigner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Admin_AdminId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Store",
                newName: "StoreName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Store",
                newName: "StoreID");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Product",
                newName: "AdminID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AdminId",
                table: "Product",
                newName: "IX_Product_AdminID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "AdminID");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Buying",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buying", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buying_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Buying_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryID",
                table: "ProductCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Buying_ClientID",
                table: "Buying",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Buying_ProductID",
                table: "Buying",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Admin_AdminID",
                table: "Product",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Category_CategoryID",
                table: "ProductCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Admin_AdminID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Category_CategoryID",
                table: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Buying");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_CategoryID",
                table: "ProductCategory");

            migrationBuilder.RenameColumn(
                name: "StoreName",
                table: "Store",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "Store",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Product",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AdminID",
                table: "Product",
                newName: "IX_Product_AdminId");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Admin",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Admin_AdminId",
                table: "Product",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id");
        }
    }
}
