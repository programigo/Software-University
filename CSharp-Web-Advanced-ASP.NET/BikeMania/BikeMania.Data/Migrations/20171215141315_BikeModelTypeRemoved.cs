namespace BikeMania.Web.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class BikeModelTypeRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Bikes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
