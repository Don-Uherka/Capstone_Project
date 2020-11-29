using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adedabea-fa7b-4588-a21c-8ad8a2f9a905");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anonymous = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    participantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "199382d8-b91f-49ed-b99e-6d4424664cb4", "fb10ce83-14a5-4ead-b0c3-2bfa1c99bf5d", "Participant", "PARTICIPANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "199382d8-b91f-49ed-b99e-6d4424664cb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adedabea-fa7b-4588-a21c-8ad8a2f9a905", "d25fcdb2-fc25-4fc9-bbfe-4a52b859b937", "Participant", "PARTICIPANT" });
        }
    }
}
