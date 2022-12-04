using Microsoft.EntityFrameworkCore.Migrations;

namespace Art_Gallery.Data.Migrations
{
    public partial class artArtistRelationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "art",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_art_ArtistID",
                table: "art",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_art_Artist_ArtistID",
                table: "art",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_art_Artist_ArtistID",
                table: "art");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_art_ArtistID",
                table: "art");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "art");
        }
    }
}
