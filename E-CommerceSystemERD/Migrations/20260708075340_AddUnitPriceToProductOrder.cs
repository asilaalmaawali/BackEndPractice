using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommerceSystemERD.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitPriceToProductOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ProductOrder",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProductOrder");
        }
    }
}
