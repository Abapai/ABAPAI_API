using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ABAPAI.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    IdFirebase = table.Column<string>(type: "varchar(300)", nullable: false),
                    Image = table.Column<string>(type: "varchar(500)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: true),
                    SignInProvider = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fan", x => x.Id);
                });

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
                    StateRegistration = table.Column<string>(type: "varchar(20)", nullable: true),
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
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "varchar(120)", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    DateTimeStart = table.Column<DateTime>(type: "Date", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "Date", nullable: false),
                    EventCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublicLimit = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DDD = table.Column<string>(type: "varchar(3)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(10)", nullable: false),
                    Name_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "varchar(300)", nullable: false),
                    EmitQrCode = table.Column<bool>(type: "bit", nullable: false),
                    Staff_ForeignKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Staff_Staff_ForeignKey",
                        column: x => x.Staff_ForeignKey,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id_address = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    City = table.Column<string>(type: "varchar(70)", nullable: true),
                    Postal_code = table.Column<string>(type: "varchar(50)", nullable: true),
                    State = table.Column<string>(type: "varchar(3)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_event = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id_address);
                    table.ForeignKey(
                        name: "FK_Address_Event_Id_event",
                        column: x => x.Id_event,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Staff_Id_user",
                        column: x => x.Id_user,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_eventFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_fanFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QrCode = table.Column<string>(type: "varchar(500)", nullable: true),
                    Payment = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Event_Id_eventFK",
                        column: x => x.Id_eventFK,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Fan_Id_fanFK",
                        column: x => x.Id_fanFK,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id_event",
                table: "Address",
                column: "Id_event",
                unique: true,
                filter: "[Id_event] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id_user",
                table: "Address",
                column: "Id_user",
                unique: true,
                filter: "[Id_user] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Staff_ForeignKey",
                table: "Event",
                column: "Staff_ForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Id_eventFK",
                table: "Ticket",
                column: "Id_eventFK");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Id_fanFK",
                table: "Ticket",
                column: "Id_fanFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Fan");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
