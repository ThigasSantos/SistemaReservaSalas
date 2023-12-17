using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaReservaSalas.Migrations
{
    /// <inheritdoc />
    public partial class migrationchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Sala_SalaId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_User_UserId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_SalaId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_UserId",
                table: "Reserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reserva_SalaId",
                table: "Reserva",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UserId",
                table: "Reserva",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Sala_SalaId",
                table: "Reserva",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_User_UserId",
                table: "Reserva",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
