using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_App.Infrastructure.Migrations
{
    public partial class AddTodoTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodoItemTagId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TodoItemsTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemsTags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoItemTagId",
                table: "TodoItems",
                column: "TodoItemTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoItemsTags_TodoItemTagId",
                table: "TodoItems",
                column: "TodoItemTagId",
                principalTable: "TodoItemsTags",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoItemsTags_TodoItemTagId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoItemsTags");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodoItemTagId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TodoItemTagId",
                table: "TodoItems");
        }
    }
}
