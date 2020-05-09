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
                    new Guid("b1732550-2b45-4eee-af19-bbf34e403ed1"), "Whatever",
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("34ec1b0c-e8fc-4394-8496-8a2ee0f6e6f4"), "Whatever",
                    new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("0ede8633-b422-4c46-b064-810f5b10f21e"), "Whatever",
                    new DateTime(2020, 5, 9, 9, 19, 2, 166, DateTimeKind.Local).AddTicks(3060), "More another type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("d002fd42-0a70-4dab-a12f-9119c643e37c"), "Whatever", new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Local),
                    "Once more another type"
                });

            migrationBuilder.CreateIndex("IX_Thing_WhateverId",
                "Thing",
                "WhateverId");
        }
    }
}