using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("64a42d96-29f3-4e2b-a8fa-e7047cbf1e52"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("8a562e7d-3947-4456-b9c7-39d9f7676dad"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("a2fd8096-7770-4897-832b-7cdffd8c7e3c"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("23a349e0-3620-45b4-87e8-8b667a7386e8"), null, true, "Finish homework" },
                    { new Guid("6eef816d-0700-49ab-b206-a88b912ec537"), "Buy milk, chocolate and bread.", false, "Shopping" },
                    { new Guid("960f291a-6417-449e-b2a7-9b2ab893c01b"), "Revise materials for exam, which will happen at 14:00 tomorrow.", false, "Cram at night" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("23a349e0-3620-45b4-87e8-8b667a7386e8"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("6eef816d-0700-49ab-b206-a88b912ec537"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("960f291a-6417-449e-b2a7-9b2ab893c01b"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("64a42d96-29f3-4e2b-a8fa-e7047cbf1e52"), "Buy milk, chocolate and bread.", false, "Shopping" },
                    { new Guid("8a562e7d-3947-4456-b9c7-39d9f7676dad"), "", true, "Finish homework" },
                    { new Guid("a2fd8096-7770-4897-832b-7cdffd8c7e3c"), "Revise materials for exam, which will happen at 14:00 tomorrow.", false, "Cram at night" }
                });
        }
    }
}
