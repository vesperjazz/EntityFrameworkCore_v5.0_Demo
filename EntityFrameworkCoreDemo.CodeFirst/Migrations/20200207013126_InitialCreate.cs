using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreDemo.CodeFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    GenderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Person_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "ID", "Code", "Name" },
                values: new object[] { new Guid("f093de04-28cf-4e10-82a8-b711e5b40da3"), "F", "Female" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "ID", "Code", "Name" },
                values: new object[] { new Guid("dd33c96a-8152-4266-9cbb-111af45befe9"), "M", "Male" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "ID", "Code", "Name" },
                values: new object[] { new Guid("3b8b18c5-d28a-43b3-a095-da15db73b668"), "U", "Unknown" });

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Code",
                table: "Gender",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GenderID",
                table: "Person",
                column: "GenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
