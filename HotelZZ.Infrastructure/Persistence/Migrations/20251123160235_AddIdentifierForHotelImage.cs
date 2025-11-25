using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelZZ.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentifierForHotelImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Hotels");
        }
    }
}
