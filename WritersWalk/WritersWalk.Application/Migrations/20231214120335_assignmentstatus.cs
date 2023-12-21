using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WritersWalk.Application.Migrations;

/// <inheritdoc />
public partial class assignmentstatus : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Status",
            table: "AssignmentAppUsers",
            type: "INTEGER",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Status",
            table: "AssignmentAppUsers");
    }
}
