using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class @event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa26d1a-38b0-465f-8fbe-847554c8d636");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Event",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2896f41-f4d7-4f14-930c-3867330c0a69", "7f819be7-f989-4122-85dd-bdf9e96ba1f9", "Participant", "PARTICIPANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2896f41-f4d7-4f14-930c-3867330c0a69");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Event",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fa26d1a-38b0-465f-8fbe-847554c8d636", "149655a4-9630-4cc5-8a24-39efebeaf412", "Participant", "PARTICIPANT" });
        }
    }
}
