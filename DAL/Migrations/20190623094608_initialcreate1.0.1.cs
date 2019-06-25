using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initialcreate101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
