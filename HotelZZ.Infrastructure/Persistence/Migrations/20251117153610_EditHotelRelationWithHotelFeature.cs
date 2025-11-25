using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelZZ.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditHotelRelationWithHotelFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFeatures_Hotels_HotelId",
                table: "HotelFeatures");

            migrationBuilder.DropIndex(
                name: "IX_HotelFeatures_HotelId",
                table: "HotelFeatures");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelFeatures");

            migrationBuilder.CreateTable(
                name: "HotelHotelFeature",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    HotelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelHotelFeature", x => new { x.FeaturesId, x.HotelsId });
                    table.ForeignKey(
                        name: "FK_HotelHotelFeature_HotelFeatures_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelHotelFeature_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelHotelFeature_HotelsId",
                table: "HotelHotelFeature",
                column: "HotelsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelHotelFeature");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_HotelId",
                table: "HotelFeatures",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFeatures_Hotels_HotelId",
                table: "HotelFeatures",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
