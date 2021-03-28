using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreDemo.CodeFirst.Migrations
{
    public partial class NullableGenderIDInPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Gender_GenderID",
                table: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenderID",
                table: "Person",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Gender_GenderID",
                table: "Person",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Gender_GenderID",
                table: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenderID",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Gender_GenderID",
                table: "Person",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
