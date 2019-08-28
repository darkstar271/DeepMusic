using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMusic.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genres_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genres_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Track_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(nullable: true),
                    Album = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Genres_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Track_ID);
                    table.ForeignKey(
                        name: "FK_Tracks_Genres_Genres_ID",
                        column: x => x.Genres_ID,
                        principalTable: "Genres",
                        principalColumn: "Genres_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Album_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(nullable: true),
                    TrackName = table.Column<string>(nullable: true),
                    AlbumCoverPath = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    TracksTrack_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Album_ID);
                    table.ForeignKey(
                        name: "FK_Albums_Tracks_TracksTrack_ID",
                        column: x => x.TracksTrack_ID,
                        principalTable: "Tracks",
                        principalColumn: "Track_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Artist_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(nullable: true),
                    Album = table.Column<string>(nullable: true),
                    AlbumCoverPath = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    AlbumsAlbum_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Artist_ID);
                    table.ForeignKey(
                        name: "FK_Artist_Albums_AlbumsAlbum_ID",
                        column: x => x.AlbumsAlbum_ID,
                        principalTable: "Albums",
                        principalColumn: "Album_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TracksTrack_ID",
                table: "Albums",
                column: "TracksTrack_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_AlbumsAlbum_ID",
                table: "Artist",
                column: "AlbumsAlbum_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_Genres_ID",
                table: "Tracks",
                column: "Genres_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
