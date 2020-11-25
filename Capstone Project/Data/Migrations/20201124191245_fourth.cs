using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fa11d29-3f3d-4d14-bd17-b2e812d84c29");

            migrationBuilder.DropColumn(
                name: "LastNight",
                table: "Participants");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Participants",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fa26d1a-38b0-465f-8fbe-847554c8d636", "149655a4-9630-4cc5-8a24-39efebeaf412", "Participant", "PARTICIPANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa26d1a-38b0-465f-8fbe-847554c8d636");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Participants");

            migrationBuilder.AddColumn<string>(
                name: "LastNight",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3fa11d29-3f3d-4d14-bd17-b2e812d84c29", "5e516b0c-633a-4027-8bc0-3fc568395399", "Participant", "PARTICIPANT" });
        }
    }
}
