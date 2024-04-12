using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomerceWebAPIs.Migrations
{
    /// <inheritdoc />
    public partial class Updateproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrice_Products_ProductPriceID",
                table: "ProductPrice");

            migrationBuilder.DropColumn(
                name: "ProductPriceID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPriceID",
                table: "ProductPrice",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductID",
                table: "ProductPrice",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrice_Products_ProductID",
                table: "ProductPrice",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrice_Products_ProductID",
                table: "ProductPrice");

            migrationBuilder.DropIndex(
                name: "IX_ProductPrice_ProductID",
                table: "ProductPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPriceID",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ProductPriceID",
                table: "ProductPrice",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrice_Products_ProductPriceID",
                table: "ProductPrice",
                column: "ProductPriceID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
