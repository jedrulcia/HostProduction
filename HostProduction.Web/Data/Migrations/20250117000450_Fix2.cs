using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostProduction.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05fb1e4f-d86f-497c-888d-169194ba7835", "AQAAAAIAAYagAAAAECWv3b20/wR8YyoJWFMEX2fZ1Ks4LjXJPGTBCyV+ZeInRTA8kWxrBZwsilvncSqLUw==", "5cfe13f9-f6d0-4e3c-8ced-2237f7e08efd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e21b2b1-40df-404c-a7c5-7807ee9e82f9", "AQAAAAIAAYagAAAAEIMRlrvVqsLZhYFmVTBEFZyzgGRxXGGkiN6TWhWaI6EyDjdAMuPFfSjIzFh+Xros7A==", "586066a6-6b17-4aeb-ba7e-052e68e2c1dc" });
        }
    }
}
