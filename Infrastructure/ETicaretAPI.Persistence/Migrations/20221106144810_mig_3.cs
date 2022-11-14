using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deneme",
                table: "Files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "deneme",
                table: "Files",
                type: "boolean",
                nullable: true);
        }
    }
}
