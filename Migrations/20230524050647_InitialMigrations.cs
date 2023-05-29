using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ap1_main.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    endereco = table.Column<string>(type: "TEXT", nullable: true),
                    telefone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    contaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    contaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numero = table.Column<int>(type: "INTEGER", nullable: false),
                    saldo = table.Column<double>(type: "REAL", nullable: false),
                    clienteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.contaId);
                    table.ForeignKey(
                        name: "FK_Conta_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    transacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contaOrigemcontaId = table.Column<int>(type: "INTEGER", nullable: true),
                    contaDestinocontaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.transacaoId);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_contaDestinocontaId",
                        column: x => x.contaDestinocontaId,
                        principalTable: "Conta",
                        principalColumn: "contaId");
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_contaOrigemcontaId",
                        column: x => x.contaOrigemcontaId,
                        principalTable: "Conta",
                        principalColumn: "contaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_clienteId",
                table: "Conta",
                column: "clienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_contaDestinocontaId",
                table: "Transacao",
                column: "contaDestinocontaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_contaOrigemcontaId",
                table: "Transacao",
                column: "contaOrigemcontaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
