using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class newname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerEntityId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CustomerEntityId",
                table: "Comments",
                newName: "CaseEntityId");

            migrationBuilder.RenameColumn(
                name: "CommentEntityId",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerEntityId",
                table: "Comments",
                newName: "IX_Comments_CaseEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CaseEntityId",
                table: "Comments",
                column: "CaseEntityId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CaseEntityId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CaseEntityId",
                table: "Comments",
                newName: "CustomerEntityId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "CommentEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CaseEntityId",
                table: "Comments",
                newName: "IX_Comments_CustomerEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "Comments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerEntityId",
                table: "Comments",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
