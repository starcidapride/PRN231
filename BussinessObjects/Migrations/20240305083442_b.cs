using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deposit_request_orchid_orchidId",
                table: "deposit_request");

            migrationBuilder.DropForeignKey(
                name: "FK_deposit_request_user_ownerId",
                table: "deposit_request");

            migrationBuilder.AlterColumn<Guid>(
                name: "ownerId",
                table: "deposit_request",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "orchidId",
                table: "deposit_request",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_deposit_request_orchid_orchidId",
                table: "deposit_request",
                column: "orchidId",
                principalTable: "orchid",
                principalColumn: "orchidId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deposit_request_user_ownerId",
                table: "deposit_request",
                column: "ownerId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deposit_request_orchid_orchidId",
                table: "deposit_request");

            migrationBuilder.DropForeignKey(
                name: "FK_deposit_request_user_ownerId",
                table: "deposit_request");

            migrationBuilder.AlterColumn<Guid>(
                name: "ownerId",
                table: "deposit_request",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "orchidId",
                table: "deposit_request",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_deposit_request_orchid_orchidId",
                table: "deposit_request",
                column: "orchidId",
                principalTable: "orchid",
                principalColumn: "orchidId");

            migrationBuilder.AddForeignKey(
                name: "FK_deposit_request_user_ownerId",
                table: "deposit_request",
                column: "ownerId",
                principalTable: "user",
                principalColumn: "userId");
        }
    }
}
