using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class Participant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_AspNetUsers_IdentityUserId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2896f41-f4d7-4f14-930c-3867330c0a69");

            migrationBuilder.DropColumn(
                name: "Founder",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_IdentityUserId",
                table: "Participant",
                newName: "IX_Participant_IdentityUserId");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adedabea-fa7b-4588-a21c-8ad8a2f9a905", "d25fcdb2-fc25-4fc9-bbfe-4a52b859b937", "Participant", "PARTICIPANT" });

            migrationBuilder.CreateIndex(
                name: "IX_Event_ParticipantId",
                table: "Event",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Participant_ParticipantId",
                table: "Event",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_AspNetUsers_IdentityUserId",
                table: "Participant",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Participant_ParticipantId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_AspNetUsers_IdentityUserId",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Event_ParticipantId",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adedabea-fa7b-4588-a21c-8ad8a2f9a905");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_IdentityUserId",
                table: "Participants",
                newName: "IX_Participants_IdentityUserId");

            migrationBuilder.AddColumn<string>(
                name: "Founder",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2896f41-f4d7-4f14-930c-3867330c0a69", "7f819be7-f989-4122-85dd-bdf9e96ba1f9", "Participant", "PARTICIPANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_AspNetUsers_IdentityUserId",
                table: "Participants",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
