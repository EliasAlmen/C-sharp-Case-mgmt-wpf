using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class NewNameMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CaseEntityId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CasesSql");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CasesSql",
                table: "CasesSql",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CasesSql_CaseEntityId",
                table: "Comments",
                column: "CaseEntityId",
                principalTable: "CasesSql",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CasesSql_CaseEntityId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CasesSql",
                table: "CasesSql");

            migrationBuilder.RenameTable(
                name: "CasesSql",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CaseEntityId",
                table: "Comments",
                column: "CaseEntityId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
