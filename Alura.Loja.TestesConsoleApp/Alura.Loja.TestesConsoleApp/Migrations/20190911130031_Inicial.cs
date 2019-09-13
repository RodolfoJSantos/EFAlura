﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.TestesConsoleApp.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
				name: "Unidade",
				table: "Produtos");

			migrationBuilder.RenameColumn(
				name: "PrecoUnitario",
				table: "Produtos",
				newName: "Preco");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "PrecoUnitario");

            migrationBuilder.AddColumn<string>(
                name: "Unidade",
                table: "Produtos",
                nullable: true);
        }
    }
}
