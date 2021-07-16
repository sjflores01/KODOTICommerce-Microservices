using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Customer",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[,]
                {
                    { 1, "Name for Client 1" },
                    { 73, "Name for Client 73" },
                    { 72, "Name for Client 72" },
                    { 71, "Name for Client 71" },
                    { 70, "Name for Client 70" },
                    { 69, "Name for Client 69" },
                    { 68, "Name for Client 68" },
                    { 67, "Name for Client 67" },
                    { 66, "Name for Client 66" },
                    { 65, "Name for Client 65" },
                    { 64, "Name for Client 64" },
                    { 63, "Name for Client 63" },
                    { 62, "Name for Client 62" },
                    { 61, "Name for Client 61" },
                    { 60, "Name for Client 60" },
                    { 59, "Name for Client 59" },
                    { 58, "Name for Client 58" },
                    { 57, "Name for Client 57" },
                    { 56, "Name for Client 56" },
                    { 55, "Name for Client 55" },
                    { 54, "Name for Client 54" },
                    { 53, "Name for Client 53" },
                    { 74, "Name for Client 74" },
                    { 52, "Name for Client 52" },
                    { 75, "Name for Client 75" },
                    { 77, "Name for Client 77" },
                    { 98, "Name for Client 98" },
                    { 97, "Name for Client 97" },
                    { 96, "Name for Client 96" },
                    { 95, "Name for Client 95" },
                    { 94, "Name for Client 94" },
                    { 93, "Name for Client 93" },
                    { 92, "Name for Client 92" },
                    { 91, "Name for Client 91" },
                    { 90, "Name for Client 90" },
                    { 89, "Name for Client 89" },
                    { 88, "Name for Client 88" },
                    { 87, "Name for Client 87" },
                    { 86, "Name for Client 86" },
                    { 85, "Name for Client 85" },
                    { 84, "Name for Client 84" },
                    { 83, "Name for Client 83" },
                    { 82, "Name for Client 82" },
                    { 81, "Name for Client 81" },
                    { 80, "Name for Client 80" },
                    { 79, "Name for Client 79" },
                    { 78, "Name for Client 78" },
                    { 76, "Name for Client 76" },
                    { 51, "Name for Client 51" },
                    { 50, "Name for Client 50" },
                    { 49, "Name for Client 49" },
                    { 22, "Name for Client 22" },
                    { 21, "Name for Client 21" },
                    { 20, "Name for Client 20" },
                    { 19, "Name for Client 19" },
                    { 18, "Name for Client 18" },
                    { 17, "Name for Client 17" },
                    { 16, "Name for Client 16" },
                    { 15, "Name for Client 15" },
                    { 14, "Name for Client 14" },
                    { 13, "Name for Client 13" },
                    { 12, "Name for Client 12" },
                    { 11, "Name for Client 11" },
                    { 10, "Name for Client 10" },
                    { 9, "Name for Client 9" },
                    { 8, "Name for Client 8" },
                    { 7, "Name for Client 7" },
                    { 6, "Name for Client 6" },
                    { 5, "Name for Client 5" },
                    { 4, "Name for Client 4" },
                    { 3, "Name for Client 3" },
                    { 2, "Name for Client 2" },
                    { 23, "Name for Client 23" },
                    { 24, "Name for Client 24" },
                    { 25, "Name for Client 25" },
                    { 26, "Name for Client 26" },
                    { 48, "Name for Client 48" },
                    { 47, "Name for Client 47" },
                    { 46, "Name for Client 46" },
                    { 45, "Name for Client 45" },
                    { 44, "Name for Client 44" },
                    { 43, "Name for Client 43" },
                    { 42, "Name for Client 42" },
                    { 41, "Name for Client 41" },
                    { 40, "Name for Client 40" },
                    { 39, "Name for Client 39" },
                    { 99, "Name for Client 99" },
                    { 38, "Name for Client 38" },
                    { 36, "Name for Client 36" },
                    { 35, "Name for Client 35" },
                    { 34, "Name for Client 34" },
                    { 33, "Name for Client 33" },
                    { 32, "Name for Client 32" },
                    { 31, "Name for Client 31" },
                    { 30, "Name for Client 30" },
                    { 29, "Name for Client 29" },
                    { 28, "Name for Client 28" },
                    { 27, "Name for Client 27" },
                    { 37, "Name for Client 37" },
                    { 100, "Name for Client 100" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientId",
                schema: "Customer",
                table: "Clients",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Customer");
        }
    }
}
