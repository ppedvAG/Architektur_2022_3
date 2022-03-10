using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ppedv.Hotelmanager.Data.EfCore.Migrations
{
    public partial class Strasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Strasse",
                table: "Gaeste",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strasse",
                table: "Gaeste");
        }
    }
}
