using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTemplate.Api.Migrations
{
    public partial class ChangedCustomerDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Vasili", "Pushkin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"),
                column: "Name",
                value: "Vasili Pushkin");
        }
    }
}
