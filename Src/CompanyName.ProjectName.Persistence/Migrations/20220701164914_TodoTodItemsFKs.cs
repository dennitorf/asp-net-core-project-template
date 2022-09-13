using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyName.ProjectName.Persistence.Migrations
{
    public partial class TodoTodItemsFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TodoItem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "TodoId",
                table: "TodoItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Todo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_TodoId",
                table: "TodoItem",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_Todo_TodoId",
                table: "TodoItem",
                column: "TodoId",
                principalTable: "Todo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_Todo_TodoId",
                table: "TodoItem");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_TodoId",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "TodoId",
                table: "TodoItem");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TodoItem",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Todo",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
