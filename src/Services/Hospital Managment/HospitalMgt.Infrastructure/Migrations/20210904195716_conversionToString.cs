using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalMgt.Infrastructure.Migrations
{
    public partial class conversionToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "hospitalManagment",
                table: "Hospitals",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Classification",
                schema: "hospitalManagment",
                table: "Hospitals",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "hospitalManagment",
                table: "Hospitals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Classification",
                schema: "hospitalManagment",
                table: "Hospitals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
