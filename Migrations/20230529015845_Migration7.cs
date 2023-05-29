using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ap1_main.Migrations
{
    /// <inheritdoc />
    public partial class Migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Conta_clienteId",
                table: "Conta");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_clienteId",
                table: "Conta",
                column: "clienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Conta_clienteId",
                table: "Conta");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_clienteId",
                table: "Conta",
                column: "clienteId",
                unique: true);
        }
    }
}
