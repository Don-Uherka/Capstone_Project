using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class FixedError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventPsrticipants",
                table: "EventPsrticipants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df96ac8a-d7b9-4c0e-843c-6adf849fc370");

            migrationBuilder.RenameTable(
                name: "EventPsrticipants",
                newName: "EventParticipants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "712d6efd-6e6a-44c3-9a51-f62b00f73c03", "ad0f343a-d4e0-4f02-8a8a-88f45766697b", "Participant", "PARTICIPANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "712d6efd-6e6a-44c3-9a51-f62b00f73c03");

            migrationBuilder.RenameTable(
                name: "EventParticipants",
                newName: "EventPsrticipants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventPsrticipants",
                table: "EventPsrticipants",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df96ac8a-d7b9-4c0e-843c-6adf849fc370", "dff3977c-6218-453b-849a-5f7a68529249", "Participant", "PARTICIPANT" });
        }
    }
}
