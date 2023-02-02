using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_App.Infrastructure.Migrations
{
    public partial class tag_property_changedTo_List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoItemsTags_TodoItemTagId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodoItemTagId",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "TodoItemTagId",
                table: "TodoItemsTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItemsTags_TodoItemTagId",
                table: "TodoItemsTags",
                column: "TodoItemTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItemsTags_TodoItems_TodoItemTagId",
                table: "TodoItemsTags",
                column: "TodoItemTagId",
                principalTable: "TodoItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItemsTags_TodoItems_TodoItemTagId",
                table: "TodoItemsTags");

            migrationBuilder.DropIndex(
                name: "IX_TodoItemsTags_TodoItemTagId",
                table: "TodoItemsTags");

            migrationBuilder.DropColumn(
                name: "TodoItemTagId",
                table: "TodoItemsTags");

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
    }
}
