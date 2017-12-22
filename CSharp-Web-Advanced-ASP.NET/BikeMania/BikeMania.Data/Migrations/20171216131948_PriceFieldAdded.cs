namespace BikeMania.Web.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PriceFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bikes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bikes");
        }
    }
}
