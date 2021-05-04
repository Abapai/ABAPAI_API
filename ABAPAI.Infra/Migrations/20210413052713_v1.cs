using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ABAPAI.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_user = table.Column<string>(type: "varchar(70)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(255)", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(255)", nullable: true),
                    StateRegistration = table.Column<string>(type: "varchar(9)", nullable: true),
                    Free = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true),
                    DDD = table.Column<string>(type: "varchar(3)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    Image = table.Column<string>(type: "varchar(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id_address = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    City = table.Column<string>(type: "varchar(70)", nullable: true),
                    Postal_code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id_address);
                    table.ForeignKey(
                        name: "FK_Address_Staff_Id_user",
                        column: x => x.Id_user,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id_user",
                table: "Address",
                column: "Id_user",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
