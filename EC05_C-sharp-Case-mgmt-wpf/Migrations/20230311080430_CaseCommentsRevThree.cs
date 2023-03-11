using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class CaseCommentsRevThree : Migration
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
                newName: "CustomersId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CaseCommentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerEntityId",
                table: "Comments",
                newName: "IX_Comments_CustomersId");

            migrationBuilder.AddColumn<int>(
                name: "CaseCommentsId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomersId",
                table: "Comments",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomersId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CaseCommentsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "Comments",
                newName: "CustomerEntityId");

            migrationBuilder.RenameColumn(
                name: "CaseCommentsId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomersId",
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
    }
}
