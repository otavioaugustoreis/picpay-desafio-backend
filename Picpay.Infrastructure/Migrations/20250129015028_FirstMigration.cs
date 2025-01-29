using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picpay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DsCPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    DsEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsSenha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TgTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "TB_CARTEIRA",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    FkUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CARTEIRA", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_TB_CARTEIRA_TB_USUARIO_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "TB_USUARIO",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRANSFERENCIA",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrValor = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    FkCarteira = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRANSFERENCIA", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkCarteira",
                        column: x => x.FkCarteira,
                        principalTable: "TB_CARTEIRA",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARTEIRA_FkUsuario",
                table: "TB_CARTEIRA",
                column: "FkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSFERENCIA_FkCarteira",
                table: "TB_TRANSFERENCIA",
                column: "FkCarteira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TRANSFERENCIA");

            migrationBuilder.DropTable(
                name: "TB_CARTEIRA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
