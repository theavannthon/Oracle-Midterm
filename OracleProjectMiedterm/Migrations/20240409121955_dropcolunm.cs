using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleProjectMiedterm.Migrations
{
    /// <inheritdoc />
    public partial class dropcolunm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasImage",
                table: "Customsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasImage",
                table: "Customsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
