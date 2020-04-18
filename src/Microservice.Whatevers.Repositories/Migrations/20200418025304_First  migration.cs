using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Whatevers.Repositories.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Thing",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    WhateverId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thing_Whatever_WhateverId",
                        column: x => x.WhateverId,
                        principalTable: "Whatever",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("059afab1-e03f-4154-8f59-a201ac6b6f72"), "Whatever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("7480dbeb-913f-4239-bddd-3453dc9ed3bf"), "Whatever", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("9aeb431d-7c1f-4c7e-a689-8ce6db155f71"), "Whatever", new DateTime(2020, 4, 17, 23, 53, 3, 808, DateTimeKind.Local).AddTicks(168), "More another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("5da530d9-15d3-4ed0-90d8-280658342e44"), "Whatever", new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), "Once more another type" });

            migrationBuilder.CreateIndex(
                name: "IX_Thing_WhateverId",
                table: "Thing",
                column: "WhateverId");
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
