using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostProduction.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFirstLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8fca03e-0c2e-4f89-a72b-c32e94c34323", "AQAAAAIAAYagAAAAEOMKx5X1fFqxxBx1gP4y/alRKwV9/YUMsbZIPdiyJwLyD1zxzoZ09P9X9DL7cPbT2w==", "4fb6df35-ea4a-42fe-867b-a5132c9651e8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68add20e-c558-42a5-beaa-a0a89b56259f", "Admin", "System", "AQAAAAIAAYagAAAAEBkplBTbcIHZjlQYSLX2ERF6BqkYBF0JCfWRqhPrBK1532g3O/agMTsFp72ZPy5ttg==", "03e1d4e5-cfa8-4c5f-b564-a2185f0350a0" });
        }
    }
}
