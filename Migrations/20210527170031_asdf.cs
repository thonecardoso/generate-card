using Microsoft.EntityFrameworkCore.Migrations;

namespace generate_card.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "User",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
