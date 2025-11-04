using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDaora.Data.Migrations
{
    /// <inheritdoc />
    public partial class bancoNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalItem",
                table: "ItensVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalItem",
                table: "ItensVenda",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
