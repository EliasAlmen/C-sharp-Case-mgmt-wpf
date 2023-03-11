using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class CaseCommentsRevTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Comments",
                newName: "CustomerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                newName: "IX_Comments_CustomerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerEntityId",
                table: "Comments",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerEntityId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CustomerEntityId",
                table: "Comments",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerEntityId",
                table: "Comments",
                newName: "IX_Comments_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
