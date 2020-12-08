using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Migrations
{
    public partial class ChangedCapPropsOnSharedPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharePosts_Participant_participantId1",
                table: "SharePosts");

            migrationBuilder.DropIndex(
                name: "IX_SharePosts_participantId1",
                table: "SharePosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1ed81c-cdce-4a20-bfc8-ba7baeaa82bf");

            migrationBuilder.DropColumn(
                name: "participantId1",
                table: "SharePosts");

            migrationBuilder.RenameColumn(
                name: "participantId",
                table: "SharePosts",
                newName: "ParticipantId");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantId",
                table: "SharePosts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58b6ea50-c4fc-4962-a95a-5b75beed5b65", "57fe2a8b-6e24-4d87-9cdb-4483955307bb", "Participant", "PARTICIPANT" });

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_ParticipantId",
                table: "SharePosts",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SharePosts_Participant_ParticipantId",
                table: "SharePosts",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharePosts_Participant_ParticipantId",
                table: "SharePosts");

            migrationBuilder.DropIndex(
                name: "IX_SharePosts_ParticipantId",
                table: "SharePosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58b6ea50-c4fc-4962-a95a-5b75beed5b65");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "SharePosts",
                newName: "participantId");

            migrationBuilder.AlterColumn<string>(
                name: "participantId",
                table: "SharePosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "participantId1",
                table: "SharePosts",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d1ed81c-cdce-4a20-bfc8-ba7baeaa82bf", "ac81f9d5-19eb-412b-95e1-609e87984d0d", "Participant", "PARTICIPANT" });

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_participantId1",
                table: "SharePosts",
                column: "participantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SharePosts_Participant_participantId1",
                table: "SharePosts",
                column: "participantId1",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
