using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWorld.Infra.Migrations
{
    /// <inheritdoc />
    public partial class dataTye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vocabularies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Vocabularies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DataType",
                table: "Vocabularies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vocabularies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Vocabularies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Vocabularies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Vocabularies");
        }
    }
}
