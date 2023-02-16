using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdaptersSQL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_Value",
                table: "Rooms",
                newName: "PriceRoom_Value");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                table: "Rooms",
                newName: "PriceRoom_Currency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceRoom_Value",
                table: "Rooms",
                newName: "Price_Value");

            migrationBuilder.RenameColumn(
                name: "PriceRoom_Currency",
                table: "Rooms",
                newName: "Price_Currency");
        }
    }
}
