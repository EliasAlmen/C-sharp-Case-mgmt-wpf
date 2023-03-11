using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class CaseCommentsRevSix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaseCommentsId",
                table: "Customers",
                newName: "CommentEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentEntityId",
                table: "Customers",
                newName: "CaseCommentsId");
        }
    }
}
