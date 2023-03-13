using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class commentEntityIdagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentEntityId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentEntityId",
                table: "Customers");
        }
    }
}
