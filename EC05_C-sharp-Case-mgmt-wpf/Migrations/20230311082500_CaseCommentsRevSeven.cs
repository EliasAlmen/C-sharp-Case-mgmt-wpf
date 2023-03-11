using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class CaseCommentsRevSeven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentEntityId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CaseCommentsId",
                table: "Comments",
                newName: "CommentEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentEntityId",
                table: "Comments",
                newName: "CaseCommentsId");

            migrationBuilder.AddColumn<int>(
                name: "CommentEntityId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
