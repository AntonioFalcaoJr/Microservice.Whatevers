using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Whatevers.Api.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thing",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Whatever",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whatever", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("32890bb3-92a3-483c-a026-4c9f05d357e5"), "Whatever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("54874289-e551-4c6c-ac96-bba45e201245"), "Whatever", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("dd0fd502-d6eb-408e-8836-754565946930"), "Whatever", new DateTime(2020, 4, 12, 1, 48, 15, 422, DateTimeKind.Local).AddTicks(2819), "More another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("ebfde1d8-2202-4ebe-856a-d8cf7dafcaf3"), "Whatever", new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Once more type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thing");

            migrationBuilder.DropTable(
                name: "Whatever");
        }
    }
}
