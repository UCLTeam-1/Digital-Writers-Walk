using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WritersWalk.Application.Migrations
{
    /// <inheritdoc />
    public partial class IsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignmentUsers_AssignmentId",
                table: "AssignmentUsers");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentTopics_AssignmentId",
                table: "AssignmentTopics");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentSurroundings_AssignmentId",
                table: "AssignmentSurroundings");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentUsers_AssignmentId_UserId",
                table: "AssignmentUsers",
                columns: new[] { "AssignmentId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentTopics_AssignmentId_TopicId",
                table: "AssignmentTopics",
                columns: new[] { "AssignmentId", "TopicId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSurroundings_AssignmentId_SurroundingsId",
                table: "AssignmentSurroundings",
                columns: new[] { "AssignmentId", "SurroundingsId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignmentUsers_AssignmentId_UserId",
                table: "AssignmentUsers");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentTopics_AssignmentId_TopicId",
                table: "AssignmentTopics");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentSurroundings_AssignmentId_SurroundingsId",
                table: "AssignmentSurroundings");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentUsers_AssignmentId",
                table: "AssignmentUsers",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentTopics_AssignmentId",
                table: "AssignmentTopics",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSurroundings_AssignmentId",
                table: "AssignmentSurroundings",
                column: "AssignmentId");
        }
    }
}
