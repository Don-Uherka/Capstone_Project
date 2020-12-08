using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d1ed81c-cdce-4a20-bfc8-ba7baeaa82bf", "ac81f9d5-19eb-412b-95e1-609e87984d0d", "Participant", "PARTICIPANT" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "Description", "EndDate", "Founder", "Latitude", "Longitude", "Name", "StartDate", "State", "ZipCode" },
                values: new object[] { 1, "117 walnut street", null, "Beaver Dam", "USA", "walk", new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don", 10m, 10m, "walk", new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "WI", 53916 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1ed81c-cdce-4a20-bfc8-ba7baeaa82bf");

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
