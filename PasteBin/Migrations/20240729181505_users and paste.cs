using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasteBin.Migrations
{
    /// <inheritdoc />
    public partial class usersandpaste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pastes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasteURL = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pastes_PasteURL",
                table: "Pastes",
                column: "PasteURL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pastes_UserID",
                table: "Pastes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pastes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
