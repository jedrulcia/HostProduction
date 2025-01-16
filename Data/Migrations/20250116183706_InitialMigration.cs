using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HostProduction.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessEquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessEquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionFacilities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Id", "Area", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 15.0m, "EQP001", "Conveyor Belt" },
                    { 2, 10.0m, "EQP002", "Mixer" },
                    { 3, 30.0m, "EQP003", "Furnace" },
                    { 4, 25.0m, "EQP004", "Press Machine" },
                    { 5, 12.0m, "EQP005", "Cutter" },
                    { 6, 18.0m, "EQP006", "Packaging Machine" },
                    { 7, 16.5m, "EQP007", "Drilling Machine" },
                    { 8, 22.0m, "EQP008", "Welding Robot" },
                    { 9, 27.0m, "EQP009", "Injection Molding Machine" },
                    { 10, 23.0m, "EQP010", "Heat Exchanger" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Id", "Code", "Name", "StandardArea" },
                values: new object[,]
                {
                    { 1, "FAC001", "Factory A", 1000.0m },
                    { 2, "FAC002", "Factory B", 1500.0m },
                    { 3, "FAC003", "Factory C", 1200.0m },
                    { 4, "FAC004", "Factory D", 2000.0m },
                    { 5, "FAC005", "Factory E", 1800.0m },
                    { 6, "FAC006", "Factory F", 2500.0m },
                    { 7, "FAC007", "Factory G", 3000.0m },
                    { 8, "FAC008", "Factory H", 3200.0m },
                    { 9, "FAC009", "Factory I", 2800.0m },
                    { 10, "FAC010", "Factory J", 3500.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessEquipmentTypes_Code",
                table: "ProcessEquipmentTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionFacilities_Code",
                table: "ProductionFacilities",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessEquipmentTypes");

            migrationBuilder.DropTable(
                name: "ProductionFacilities");
        }
    }
}
