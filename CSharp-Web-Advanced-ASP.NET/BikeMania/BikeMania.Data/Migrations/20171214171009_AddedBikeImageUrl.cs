namespace BikeMania.Web.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedBikeImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_AspNetUsers_UserId",
                table: "Bikes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Bikes",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_AspNetUsers_UserId",
                table: "Bikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_AspNetUsers_UserId",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Bikes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_AspNetUsers_UserId",
                table: "Bikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
