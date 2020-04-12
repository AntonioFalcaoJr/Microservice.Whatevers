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
            migrationBuilder.CreateTable("Thing",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Name = table.Column<string>(),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<double>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thing", x => x.Id);
                });

            migrationBuilder.CreateTable("Whatever",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Name = table.Column<string>(),
                    Time = table.Column<DateTime>(),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whatever", x => x.Id);
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("491f4d02-7361-4740-b251-6917105eaf94"), "Whatever",
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("f45a9688-0dda-4e57-b1d2-b8d6f59bf892"), "Whatever",
                    new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Another type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("92fe8164-1e26-407a-aeee-6d6297416666"), "Whatever",
                    new DateTime(2020, 4, 12, 14, 49, 47, 417, DateTimeKind.Local).AddTicks(9161), "More another type"
                });

            migrationBuilder.InsertData("Whatever",
                new[] {"Id", "Name", "Time", "Type"},
                new object[]
                {
                    new Guid("10b38c17-0e76-427a-84a6-f2c6c514858c"), "Whatever",
                    new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Once more type"
                });
        }
    }
}