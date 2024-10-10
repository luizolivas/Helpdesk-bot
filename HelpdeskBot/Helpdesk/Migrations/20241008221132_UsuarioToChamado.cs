using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskBot.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioToChamado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioInterno",
                table: "Chamado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioInternoId",
                table: "Chamado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_UsuarioInternoId",
                table: "Chamado",
                column: "UsuarioInternoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_UsuarioInterno_UsuarioInternoId",
                table: "Chamado",
                column: "UsuarioInternoId",
                principalTable: "UsuarioInterno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_UsuarioInterno_UsuarioInternoId",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_UsuarioInternoId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioInterno",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "UsuarioInternoId",
                table: "Chamado");
        }
    }
}
