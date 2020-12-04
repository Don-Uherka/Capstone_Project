using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class EventParticipants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "199382d8-b91f-49ed-b99e-6d4424664cb4");

            migrationBuilder.CreateTable(
                name: "EventPsrticipants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Favorite = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPsrticipants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df96ac8a-d7b9-4c0e-843c-6adf849fc370", "dff3977c-6218-453b-849a-5f7a68529249", "Participant", "PARTICIPANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPsrticipants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df96ac8a-d7b9-4c0e-843c-6adf849fc370");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "199382d8-b91f-49ed-b99e-6d4424664cb4", "fb10ce83-14a5-4ead-b0c3-2bfa1c99bf5d", "Participant", "PARTICIPANT" });
        }
    }
}
