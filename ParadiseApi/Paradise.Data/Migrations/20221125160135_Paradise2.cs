using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace Paradise.Data.Migrations
{
    /// <inheritdoc />
    public partial class Paradise2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Profiles",
                newName:"IdUser");
            
            migrationBuilder.CreateIndex(
                name: "IX_Profiles_IdUser",
                table: "Profiles",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_IdUser",
                table: "Profiles",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_IdUser",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_IdUser",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
