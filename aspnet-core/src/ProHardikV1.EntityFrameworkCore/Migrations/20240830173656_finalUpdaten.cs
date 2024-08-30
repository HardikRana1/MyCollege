using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProHardikV1.Migrations
{
    /// <inheritdoc />
    public partial class finalUpdaten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Colleges",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Colleges");
        }
    }
}
