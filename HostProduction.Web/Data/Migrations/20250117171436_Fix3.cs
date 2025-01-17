using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostProduction.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68add20e-c558-42a5-beaa-a0a89b56259f", "AQAAAAIAAYagAAAAEBkplBTbcIHZjlQYSLX2ERF6BqkYBF0JCfWRqhPrBK1532g3O/agMTsFp72ZPy5ttg==", "03e1d4e5-cfa8-4c5f-b564-a2185f0350a0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05fb1e4f-d86f-497c-888d-169194ba7835", "AQAAAAIAAYagAAAAECWv3b20/wR8YyoJWFMEX2fZ1Ks4LjXJPGTBCyV+ZeInRTA8kWxrBZwsilvncSqLUw==", "5cfe13f9-f6d0-4e3c-8ced-2237f7e08efd" });
        }
    }
}
