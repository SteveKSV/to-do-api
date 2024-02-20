using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
