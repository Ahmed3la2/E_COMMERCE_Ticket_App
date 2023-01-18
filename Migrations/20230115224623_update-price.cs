using Microsoft.EntityFrameworkCore.Migrations;

namespace E_ticket.Migrations
{
    public partial class updateprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_cinemas_cinemaId",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_producers_ProducerId",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "cinemaId",
                table: "movies",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_movies_cinemaId",
                table: "movies",
                newName: "IX_movies_CinemaId");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_cinemas_CinemaId",
                table: "movies",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_producers_ProducerId",
                table: "movies",
                column: "ProducerId",
                principalTable: "producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_cinemas_CinemaId",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_producers_ProducerId",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "movies",
                newName: "cinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_movies_CinemaId",
                table: "movies",
                newName: "IX_movies_cinemaId");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "cinemaId",
                table: "movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_cinemas_cinemaId",
                table: "movies",
                column: "cinemaId",
                principalTable: "cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_producers_ProducerId",
                table: "movies",
                column: "ProducerId",
                principalTable: "producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
