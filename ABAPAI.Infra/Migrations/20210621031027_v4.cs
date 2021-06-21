using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABAPAI.Infra.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Fan_Id_fanFK",
                table: "Ticket");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_fanFK",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "QuantityConfirmed",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Fan_Id_fanFK",
                table: "Ticket",
                column: "Id_fanFK",
                principalTable: "Fan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Fan_Id_fanFK",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "QuantityConfirmed",
                table: "Event");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_fanFK",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Fan_Id_fanFK",
                table: "Ticket",
                column: "Id_fanFK",
                principalTable: "Fan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
