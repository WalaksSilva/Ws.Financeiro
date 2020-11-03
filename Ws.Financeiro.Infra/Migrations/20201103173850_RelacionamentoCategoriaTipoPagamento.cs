using Microsoft.EntityFrameworkCore.Migrations;

namespace Ws.Financeiro.Infra.Migrations
{
    public partial class RelacionamentoCategoriaTipoPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "TipoPagamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPagamentos_IdUsuario",
                table: "TipoPagamentos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdUsuario",
                table: "Categorias",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_AspNetUsers_IdUsuario",
                table: "Categorias",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPagamentos_AspNetUsers_IdUsuario",
                table: "TipoPagamentos",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_AspNetUsers_IdUsuario",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPagamentos_AspNetUsers_IdUsuario",
                table: "TipoPagamentos");

            migrationBuilder.DropIndex(
                name: "IX_TipoPagamentos_IdUsuario",
                table: "TipoPagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_IdUsuario",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "TipoPagamentos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Categorias");
        }
    }
}
