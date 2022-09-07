using Microsoft.EntityFrameworkCore.Migrations;

using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace IzradaFilmova.Database.Migrations
{
    public partial class UserActorDirectorRelations : Migration
    {
        protected override void Up([NotNull] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "ActorMovieRelations",
                newName: "RequestedSalary");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Directors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Actors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentSalary",
                table: "ActorMovieRelations",
                type: "decimal(16,2)",
                precision: 16,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_UserId",
                table: "Directors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_UserId",
                table: "Actors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_AspNetUsers_UserId",
                table: "Actors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_AspNetUsers_UserId",
                table: "Directors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down([NotNull] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_AspNetUsers_UserId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Directors_AspNetUsers_UserId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_UserId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_UserId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "CurrentSalary",
                table: "ActorMovieRelations");

            migrationBuilder.RenameColumn(
                name: "RequestedSalary",
                table: "ActorMovieRelations",
                newName: "Salary");
        }
    }
}
