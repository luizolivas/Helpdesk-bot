using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskBot.Migrations
{
    /// <inheritdoc />
    public partial class InternalDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InternalDescription",
                table: "Chamado",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalDescription",
                table: "Chamado");
        }
    }
}
