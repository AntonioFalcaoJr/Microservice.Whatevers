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
                values: new object[] { new Guid("d54c0aab-0014-4270-a6d6-ec3b4f6da372"), "Whatever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("5b72f8d7-4f33-480a-ad05-93672580a456"), "Whatever", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("f1934e57-61fa-4a84-b281-d43d005a7331"), "Whatever", new DateTime(2020, 4, 17, 23, 6, 32, 444, DateTimeKind.Local).AddTicks(3156), "More another type" });

            migrationBuilder.InsertData(
                table: "Whatever",
                columns: new[] { "Id", "Name", "Time", "Type" },
                values: new object[] { new Guid("f08e706c-c599-4e9f-8ae1-e873ff404b75"), "Whatever", new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), "Once more another type" });

            migrationBuilder.InsertData(
                table: "Thing",
                columns: new[] { "Id", "Name", "Type", "Value", "WhateverId" },
                values: new object[] { new Guid("8cf9506f-a19e-4ece-be56-89ef57572fc7"), "Thing", "Some type", 5.0, new Guid("d54c0aab-0014-4270-a6d6-ec3b4f6da372") });

            migrationBuilder.InsertData(
                table: "Thing",
                columns: new[] { "Id", "Name", "Type", "Value", "WhateverId" },
                values: new object[] { new Guid("4c1c68f7-c95f-4a2a-ba1f-a4ae72c5e530"), "Thing", "Another type", 5.0, new Guid("5b72f8d7-4f33-480a-ad05-93672580a456") });

            migrationBuilder.InsertData(
                table: "Thing",
                columns: new[] { "Id", "Name", "Type", "Value", "WhateverId" },
                values: new object[] { new Guid("865d1e49-165f-4fef-aebd-817133b73828"), "Thing", "More another type", 5.0, new Guid("f1934e57-61fa-4a84-b281-d43d005a7331") });

            migrationBuilder.InsertData(
                table: "Thing",
                columns: new[] { "Id", "Name", "Type", "Value", "WhateverId" },
                values: new object[] { new Guid("3c02b410-b02b-438a-a87e-1226e1a69141"), "Thing", "Once more another type", 5.0, new Guid("f08e706c-c599-4e9f-8ae1-e873ff404b75") });

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
