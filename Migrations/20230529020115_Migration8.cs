using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ap1_main.Migrations
{
    /// <inheritdoc />
    public partial class Migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contaId",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "contaId",
                table: "Cliente",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
