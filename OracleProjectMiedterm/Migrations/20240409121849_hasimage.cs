using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleProjectMiedterm.Migrations
{
    /// <inheritdoc />
    public partial class hasimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasImage",
                table: "Customsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasImage",
                table: "Customsers");
        }
    }
}
