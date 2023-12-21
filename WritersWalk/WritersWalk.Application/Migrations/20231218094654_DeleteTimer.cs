using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WritersWalk.Application.Migrations;

/// <inheritdoc />
public partial class DeleteTimer : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "WritersWalkTimers");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "WritersWalkTimers",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                AppUserId1 = table.Column<string>(type: "TEXT", nullable: false),
                AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                EndTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                StartTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WritersWalkTimers", x => x.Id);
                table.ForeignKey(
                    name: "FK_WritersWalkTimers_Users_AppUserId1",
                    column: x => x.AppUserId1,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_WritersWalkTimers_AppUserId1",
            table: "WritersWalkTimers",
            column: "AppUserId1");
    }
}
