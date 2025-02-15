using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picpay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizandobd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkCarteira",
                table: "TB_TRANSFERENCIA");

            migrationBuilder.RenameColumn(
                name: "FkCarteira",
                table: "TB_TRANSFERENCIA",
                newName: "FkRecebidor");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TRANSFERENCIA_FkCarteira",
                table: "TB_TRANSFERENCIA",
                newName: "IX_TB_TRANSFERENCIA_FkRecebidor");

            migrationBuilder.AddColumn<int>(
                name: "FkPagador",
                table: "TB_TRANSFERENCIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSFERENCIA_FkPagador",
                table: "TB_TRANSFERENCIA",
                column: "FkPagador");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkPagador",
                table: "TB_TRANSFERENCIA",
                column: "FkPagador",
                principalTable: "TB_CARTEIRA",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkRecebidor",
                table: "TB_TRANSFERENCIA",
                column: "FkRecebidor",
                principalTable: "TB_CARTEIRA",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkPagador",
                table: "TB_TRANSFERENCIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkRecebidor",
                table: "TB_TRANSFERENCIA");

            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSFERENCIA_FkPagador",
                table: "TB_TRANSFERENCIA");

            migrationBuilder.DropColumn(
                name: "FkPagador",
                table: "TB_TRANSFERENCIA");

            migrationBuilder.RenameColumn(
                name: "FkRecebidor",
                table: "TB_TRANSFERENCIA",
                newName: "FkCarteira");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TRANSFERENCIA_FkRecebidor",
                table: "TB_TRANSFERENCIA",
                newName: "IX_TB_TRANSFERENCIA_FkCarteira");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TRANSFERENCIA_TB_CARTEIRA_FkCarteira",
                table: "TB_TRANSFERENCIA",
                column: "FkCarteira",
                principalTable: "TB_CARTEIRA",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
