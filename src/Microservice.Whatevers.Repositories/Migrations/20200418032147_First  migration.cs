using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Whatevers.Repositories.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Thing");

            migrationBuilder.DropTable("Whatever");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Whatever",
                table => new
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

            migrationBuilder.CreateTable("Thing",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    WhateverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                    table.ForeignKey("FK_Thing_Whatever_WhateverId",
                        x => x.WhateverId,
                        "Whatever",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("c267dc0e-8829-49a9-9d1c-54e1488298f4"), "Whatever",
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("e43bf835-dac0-4805-a29b-4117d3cf06ea"), "Whatever",
                    new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("532b162e-f5a4-4595-a8a8-cc9e4270a05f"), "Whatever",
                    new DateTime(2020, 4, 18, 0, 21, 46, 898, DateTimeKind.Local).AddTicks(5592), "More another type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("9288ccdf-bd54-4a45-82c7-1b0351baf2f5"), "Whatever",
                    new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), "Once more another type"
                });

            migrationBuilder.CreateIndex("IX_Thing_WhateverId",
                "Thing",
                "WhateverId");
        }
    }
}