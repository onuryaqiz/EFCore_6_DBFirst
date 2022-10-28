using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyEFCore.CodeFirst.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "products");

            migrationBuilder.CreateTable(
                name: "ProductTb",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTb", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTb",
                schema: "products");
        }
    }
}
