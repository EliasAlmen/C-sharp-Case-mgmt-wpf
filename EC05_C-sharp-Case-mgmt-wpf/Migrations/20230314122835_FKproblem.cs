using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class FKproblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesSql_OwnerSql_OwnerEntityId",
                table: "CasesSql");

            migrationBuilder.DropColumn(
                name: "CommentEntityId",
                table: "CasesSql");

            migrationBuilder.RenameColumn(
                name: "OwnerEntityId",
                table: "CasesSql",
                newName: "OwnerEntityOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_CasesSql_OwnerEntityId",
                table: "CasesSql",
                newName: "IX_CasesSql_OwnerEntityOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesSql_OwnerSql_OwnerEntityOwnerId",
                table: "CasesSql",
                column: "OwnerEntityOwnerId",
                principalTable: "OwnerSql",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesSql_OwnerSql_OwnerEntityOwnerId",
                table: "CasesSql");

            migrationBuilder.RenameColumn(
                name: "OwnerEntityOwnerId",
                table: "CasesSql",
                newName: "OwnerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_CasesSql_OwnerEntityOwnerId",
                table: "CasesSql",
                newName: "IX_CasesSql_OwnerEntityId");

            migrationBuilder.AddColumn<int>(
                name: "CommentEntityId",
                table: "CasesSql",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CasesSql_OwnerSql_OwnerEntityId",
                table: "CasesSql",
                column: "OwnerEntityId",
                principalTable: "OwnerSql",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
