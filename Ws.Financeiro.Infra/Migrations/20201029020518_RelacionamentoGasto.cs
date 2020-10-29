using Microsoft.EntityFrameworkCore.Migrations;

namespace Ws.Financeiro.Infra.Migrations
{
    public partial class RelacionamentoGasto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Gastos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdUsuario",
                table: "Gastos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_AspNetUsers_IdUsuario",
                table: "Gastos",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_AspNetUsers_IdUsuario",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_IdUsuario",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Gastos");
        }
    }
}
