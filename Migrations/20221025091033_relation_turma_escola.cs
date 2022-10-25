using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaAPI.Migrations
{
    public partial class relation_turma_escola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EscolaID",
                table: "Turmas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolaID",
                table: "Turmas",
                column: "EscolaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Escolas_EscolaID",
                table: "Turmas",
                column: "EscolaID",
                principalTable: "Escolas",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Escolas_EscolaID",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_EscolaID",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "EscolaID",
                table: "Turmas");
        }
    }
}
