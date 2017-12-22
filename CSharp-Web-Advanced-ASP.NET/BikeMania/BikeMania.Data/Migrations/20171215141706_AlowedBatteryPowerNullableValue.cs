namespace BikeMania.Web.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AlowedBatteryPowerNullableValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BatteryPower",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BatteryPower",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
