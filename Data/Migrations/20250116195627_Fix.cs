using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostProduction.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6525060-8501-4e2c-9ae9-7c2eca43dd0e", "AQAAAAIAAYagAAAAEMmzrgtupBjIMPEdOZc3ixBakaxnCZXFJk5egveKm8AISAWK3dFr85ovRhhIYjbOCQ==", "4b6a0d94-f2d2-4c18-ab73-85c4b2a14c69" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "654bced5-375b-5291-0a59-1dc59923d1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f8c190b-f86d-47d1-9f4c-7ef8b8f4c3a8", "AQAAAAIAAYagAAAAEGumH0INGvqRDFXEZrZsNdSeK1oTHN9wpyoI8cXGGOUgPeR4XTaZTwic9FF90vo7Rg==", "084a6e10-5f4c-4119-88be-4c04f17ff4a4" });
        }
    }
}
