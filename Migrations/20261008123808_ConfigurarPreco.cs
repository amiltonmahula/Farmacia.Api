using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmacia.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarPreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "ItensVendas");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitario",
                table: "ItensVendas",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItensVendas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "ItensVendas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItensVendas");

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "ItensVendas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
