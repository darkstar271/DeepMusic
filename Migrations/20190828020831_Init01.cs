using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMusic.Migrations
{
    public partial class Init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackName",
                table: "Albums",
                newName: "Track");

            migrationBuilder.AddColumn<string>(
                name: "Track",
                table: "Tracks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Track",
                table: "Tracks");

            migrationBuilder.RenameColumn(
                name: "Track",
                table: "Albums",
                newName: "TrackName");
        }
    }
}
