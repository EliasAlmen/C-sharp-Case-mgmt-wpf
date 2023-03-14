using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnerSql",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerSql", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "CasesSql",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    OwnerEntityId = table.Column<int>(type: "int", nullable: false),
                    CommentEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesSql", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_CasesSql_OwnerSql_OwnerEntityId",
                        column: x => x.OwnerEntityId,
                        principalTable: "OwnerSql",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatusSql",
                columns: table => new
                {
                    CaseStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatusSql", x => x.CaseStatusId);
                    table.ForeignKey(
                        name: "FK_CaseStatusSql_CasesSql_CaseEntityId",
                        column: x => x.CaseEntityId,
                        principalTable: "CasesSql",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsSql",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentAuthor = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsSql", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentsSql_CasesSql_CaseEntityId",
                        column: x => x.CaseEntityId,
                        principalTable: "CasesSql",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasesSql_OwnerEntityId",
                table: "CasesSql",
                column: "OwnerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatusSql_CaseEntityId",
                table: "CaseStatusSql",
                column: "CaseEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentsSql_CaseEntityId",
                table: "CommentsSql",
                column: "CaseEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseStatusSql");

            migrationBuilder.DropTable(
                name: "CommentsSql");

            migrationBuilder.DropTable(
                name: "CasesSql");

            migrationBuilder.DropTable(
                name: "OwnerSql");
        }
    }
}
