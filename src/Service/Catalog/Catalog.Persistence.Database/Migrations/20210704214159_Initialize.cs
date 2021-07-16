using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 637m },
                    { 73, "Description for product 73", "Product 73", 372m },
                    { 72, "Description for product 72", "Product 72", 745m },
                    { 71, "Description for product 71", "Product 71", 939m },
                    { 70, "Description for product 70", "Product 70", 886m },
                    { 69, "Description for product 69", "Product 69", 513m },
                    { 68, "Description for product 68", "Product 68", 593m },
                    { 67, "Description for product 67", "Product 67", 679m },
                    { 66, "Description for product 66", "Product 66", 181m },
                    { 65, "Description for product 65", "Product 65", 445m },
                    { 64, "Description for product 64", "Product 64", 640m },
                    { 63, "Description for product 63", "Product 63", 897m },
                    { 62, "Description for product 62", "Product 62", 297m },
                    { 61, "Description for product 61", "Product 61", 608m },
                    { 60, "Description for product 60", "Product 60", 328m },
                    { 59, "Description for product 59", "Product 59", 678m },
                    { 58, "Description for product 58", "Product 58", 860m },
                    { 57, "Description for product 57", "Product 57", 927m },
                    { 56, "Description for product 56", "Product 56", 376m },
                    { 55, "Description for product 55", "Product 55", 278m },
                    { 54, "Description for product 54", "Product 54", 535m },
                    { 53, "Description for product 53", "Product 53", 878m },
                    { 74, "Description for product 74", "Product 74", 390m },
                    { 52, "Description for product 52", "Product 52", 315m },
                    { 75, "Description for product 75", "Product 75", 926m },
                    { 77, "Description for product 77", "Product 77", 376m },
                    { 98, "Description for product 98", "Product 98", 443m },
                    { 97, "Description for product 97", "Product 97", 997m },
                    { 96, "Description for product 96", "Product 96", 375m },
                    { 95, "Description for product 95", "Product 95", 110m },
                    { 94, "Description for product 94", "Product 94", 852m },
                    { 93, "Description for product 93", "Product 93", 121m },
                    { 92, "Description for product 92", "Product 92", 814m },
                    { 91, "Description for product 91", "Product 91", 564m },
                    { 90, "Description for product 90", "Product 90", 955m },
                    { 89, "Description for product 89", "Product 89", 336m },
                    { 88, "Description for product 88", "Product 88", 502m },
                    { 87, "Description for product 87", "Product 87", 547m },
                    { 86, "Description for product 86", "Product 86", 604m },
                    { 85, "Description for product 85", "Product 85", 210m },
                    { 84, "Description for product 84", "Product 84", 604m },
                    { 83, "Description for product 83", "Product 83", 271m },
                    { 82, "Description for product 82", "Product 82", 233m },
                    { 81, "Description for product 81", "Product 81", 788m },
                    { 80, "Description for product 80", "Product 80", 650m },
                    { 79, "Description for product 79", "Product 79", 227m },
                    { 78, "Description for product 78", "Product 78", 904m },
                    { 76, "Description for product 76", "Product 76", 700m },
                    { 51, "Description for product 51", "Product 51", 334m },
                    { 50, "Description for product 50", "Product 50", 618m },
                    { 49, "Description for product 49", "Product 49", 957m },
                    { 22, "Description for product 22", "Product 22", 360m },
                    { 21, "Description for product 21", "Product 21", 594m },
                    { 20, "Description for product 20", "Product 20", 499m },
                    { 19, "Description for product 19", "Product 19", 909m },
                    { 18, "Description for product 18", "Product 18", 453m },
                    { 17, "Description for product 17", "Product 17", 446m },
                    { 16, "Description for product 16", "Product 16", 615m },
                    { 15, "Description for product 15", "Product 15", 379m },
                    { 14, "Description for product 14", "Product 14", 745m },
                    { 13, "Description for product 13", "Product 13", 108m },
                    { 12, "Description for product 12", "Product 12", 617m },
                    { 11, "Description for product 11", "Product 11", 508m },
                    { 10, "Description for product 10", "Product 10", 265m },
                    { 9, "Description for product 9", "Product 9", 985m },
                    { 8, "Description for product 8", "Product 8", 120m },
                    { 7, "Description for product 7", "Product 7", 426m },
                    { 6, "Description for product 6", "Product 6", 673m },
                    { 5, "Description for product 5", "Product 5", 964m },
                    { 4, "Description for product 4", "Product 4", 522m },
                    { 3, "Description for product 3", "Product 3", 718m },
                    { 2, "Description for product 2", "Product 2", 729m },
                    { 23, "Description for product 23", "Product 23", 801m },
                    { 24, "Description for product 24", "Product 24", 858m },
                    { 25, "Description for product 25", "Product 25", 843m },
                    { 26, "Description for product 26", "Product 26", 735m },
                    { 48, "Description for product 48", "Product 48", 930m },
                    { 47, "Description for product 47", "Product 47", 947m },
                    { 46, "Description for product 46", "Product 46", 293m },
                    { 45, "Description for product 45", "Product 45", 731m },
                    { 44, "Description for product 44", "Product 44", 896m },
                    { 43, "Description for product 43", "Product 43", 984m },
                    { 42, "Description for product 42", "Product 42", 894m },
                    { 41, "Description for product 41", "Product 41", 573m },
                    { 40, "Description for product 40", "Product 40", 618m },
                    { 39, "Description for product 39", "Product 39", 180m },
                    { 99, "Description for product 99", "Product 99", 550m },
                    { 38, "Description for product 38", "Product 38", 700m },
                    { 36, "Description for product 36", "Product 36", 492m },
                    { 35, "Description for product 35", "Product 35", 332m },
                    { 34, "Description for product 34", "Product 34", 515m },
                    { 33, "Description for product 33", "Product 33", 937m },
                    { 32, "Description for product 32", "Product 32", 426m },
                    { 31, "Description for product 31", "Product 31", 819m },
                    { 30, "Description for product 30", "Product 30", 444m },
                    { 29, "Description for product 29", "Product 29", 222m },
                    { 28, "Description for product 28", "Product 28", 228m },
                    { 27, "Description for product 27", "Product 27", 164m },
                    { 37, "Description for product 37", "Product 37", 675m },
                    { 100, "Description for product 100", "Product 100", 649m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 73, 73, 15 },
                    { 72, 72, 15 },
                    { 71, 71, 10 },
                    { 70, 70, 8 },
                    { 69, 69, 7 },
                    { 68, 68, 7 },
                    { 67, 67, 17 },
                    { 66, 66, 0 },
                    { 65, 65, 19 },
                    { 64, 64, 4 },
                    { 63, 63, 2 },
                    { 62, 62, 7 },
                    { 61, 61, 18 },
                    { 60, 60, 3 },
                    { 59, 59, 6 },
                    { 58, 58, 14 },
                    { 57, 57, 11 },
                    { 56, 56, 13 },
                    { 55, 55, 11 },
                    { 54, 54, 3 },
                    { 53, 53, 7 },
                    { 74, 74, 19 },
                    { 52, 52, 14 },
                    { 75, 75, 19 },
                    { 77, 77, 3 },
                    { 98, 98, 0 },
                    { 97, 97, 6 },
                    { 96, 96, 19 },
                    { 95, 95, 14 },
                    { 94, 94, 14 },
                    { 93, 93, 18 },
                    { 92, 92, 2 },
                    { 91, 91, 3 },
                    { 90, 90, 12 },
                    { 89, 89, 14 },
                    { 88, 88, 3 },
                    { 87, 87, 11 },
                    { 86, 86, 7 },
                    { 85, 85, 9 },
                    { 84, 84, 17 },
                    { 83, 83, 17 },
                    { 82, 82, 9 },
                    { 81, 81, 5 },
                    { 80, 80, 0 },
                    { 79, 79, 1 },
                    { 78, 78, 13 },
                    { 76, 76, 5 },
                    { 51, 51, 2 },
                    { 50, 50, 4 },
                    { 49, 49, 16 },
                    { 22, 22, 8 },
                    { 21, 21, 14 },
                    { 20, 20, 6 },
                    { 19, 19, 12 },
                    { 18, 18, 13 },
                    { 17, 17, 1 },
                    { 16, 16, 8 },
                    { 15, 15, 3 },
                    { 14, 14, 13 },
                    { 13, 13, 13 },
                    { 12, 12, 4 },
                    { 11, 11, 19 },
                    { 10, 10, 1 },
                    { 9, 9, 16 },
                    { 8, 8, 4 },
                    { 7, 7, 1 },
                    { 6, 6, 6 },
                    { 5, 5, 7 },
                    { 4, 4, 9 },
                    { 3, 3, 2 },
                    { 2, 2, 4 },
                    { 23, 23, 12 },
                    { 24, 24, 8 },
                    { 25, 25, 2 },
                    { 26, 26, 4 },
                    { 48, 48, 18 },
                    { 47, 47, 18 },
                    { 46, 46, 1 },
                    { 45, 45, 6 },
                    { 44, 44, 18 },
                    { 43, 43, 4 },
                    { 42, 42, 8 },
                    { 41, 41, 7 },
                    { 40, 40, 13 },
                    { 39, 39, 17 },
                    { 99, 99, 18 },
                    { 38, 38, 5 },
                    { 36, 36, 15 },
                    { 35, 35, 5 },
                    { 34, 34, 5 },
                    { 33, 33, 7 },
                    { 32, 32, 18 },
                    { 31, 31, 1 },
                    { 30, 30, 12 },
                    { 29, 29, 2 },
                    { 28, 28, 14 },
                    { 27, 27, 7 },
                    { 37, 37, 17 },
                    { 100, 100, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
