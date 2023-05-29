using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ap1_main.Migrations
{
    /// <inheritdoc />
    public partial class Migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "clienteCPF",
                table: "Conta",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clienteCPF",
                table: "Conta");
        }
    }
}
