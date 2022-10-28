using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyEFCore.CodeFirst.Migrations
{
    public partial class ChangeOrderOrColumnName_ForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "products",
                table: "ProductTb",
                newName: "price2");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "products",
                table: "ProductTb",
                newName: "name2");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "products",
                table: "ProductTb",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "price2",
                schema: "products",
                table: "ProductTb",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "name2",
                schema: "products",
                table: "ProductTb",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price2",
                schema: "products",
                table: "ProductTb",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name2",
                schema: "products",
                table: "ProductTb",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "products",
                table: "ProductTb",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "products",
                table: "ProductTb",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "products",
                table: "ProductTb",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 2);
        }
    }
}
