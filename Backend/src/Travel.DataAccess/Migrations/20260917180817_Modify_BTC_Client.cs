using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Modify_BTC_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "PrimaryAgreements");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "PrimaryAgreements");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchieved",
                table: "PrimaryAgreements",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchieved",
                table: "PrimaryAgreements");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "PrimaryAgreements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "PrimaryAgreements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
