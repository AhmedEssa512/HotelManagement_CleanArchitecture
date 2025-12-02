using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelZZ.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicIdToRoomImageTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "RoomImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "RoomImages");
        }
    }
}
