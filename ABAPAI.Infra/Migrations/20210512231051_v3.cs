using Microsoft.EntityFrameworkCore.Migrations;

namespace ABAPAI.Infra.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Address",
                type: "varchar(3)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Address",
                type: "varchar(50)",
                nullable: true);
        }
    }
}
