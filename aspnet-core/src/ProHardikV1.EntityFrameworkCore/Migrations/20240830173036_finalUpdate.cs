using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProHardikV1.Migrations
{
    /// <inheritdoc />
    public partial class finalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Colleges",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Colleges",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Colleges",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Colleges",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Colleges",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Colleges",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Colleges");
        }
    }
}
