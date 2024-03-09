using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    walletAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", maxLength: 50, nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orchid",
                columns: table => new
                {
                    orchidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    imageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ownerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    depositedStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orchid", x => x.orchidId);
                    table.ForeignKey(
                        name: "FK_orchid_user_ownerId",
                        column: x => x.ownerId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "deposit_request",
                columns: table => new
                {
                    depositRequestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateStart = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ownerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    orchidId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deposit_request", x => x.depositRequestId);
                    table.ForeignKey(
                        name: "FK_deposit_request_orchid_orchidId",
                        column: x => x.orchidId,
                        principalTable: "orchid",
                        principalColumn: "orchidId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deposit_request_user_ownerId",
                        column: x => x.ownerId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_deposit_request_orchidId",
                table: "deposit_request",
                column: "orchidId");

            migrationBuilder.CreateIndex(
                name: "IX_deposit_request_ownerId",
                table: "deposit_request",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "IX_orchid_ownerId",
                table: "orchid",
                column: "ownerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deposit_request");

            migrationBuilder.DropTable(
                name: "orchid");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
