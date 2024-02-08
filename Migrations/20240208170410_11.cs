using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baigiamasis2.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAdress_AdressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserAdress",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdress_UserId",
                table: "UserAdress",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdress_Users_UserId",
                table: "UserAdress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAdress_Users_UserId",
                table: "UserAdress");

            migrationBuilder.DropIndex(
                name: "IX_UserAdress_UserId",
                table: "UserAdress");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAdress");

            migrationBuilder.AddColumn<long>(
                name: "AdressId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdressId",
                table: "Users",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAdress_AdressId",
                table: "Users",
                column: "AdressId",
                principalTable: "UserAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
