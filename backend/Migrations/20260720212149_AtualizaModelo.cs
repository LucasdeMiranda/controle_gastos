using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Pessoas_Pessoaid",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Transacoes",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Pessoaid",
                table: "Transacoes",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_Pessoaid",
                table: "Transacoes",
                newName: "IX_Transacoes_PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Pessoas_PessoaId",
                table: "Transacoes",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Pessoas_PessoaId",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Transacoes",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Transacoes",
                newName: "Pessoaid");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_PessoaId",
                table: "Transacoes",
                newName: "IX_Transacoes_Pessoaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Pessoas_Pessoaid",
                table: "Transacoes",
                column: "Pessoaid",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
