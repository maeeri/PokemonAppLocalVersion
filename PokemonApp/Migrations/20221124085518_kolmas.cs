using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonApp.Migrations
{
    public partial class kolmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    OtherUser = table.Column<int>(type: "int", nullable: false),
                    OtherUserNavigationId = table.Column<int>(type: "int", nullable: true),
                    UserNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connection_User_OtherUserNavigationId",
                        column: x => x.OtherUserNavigationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Connection_User_UserNavigationId",
                        column: x => x.UserNavigationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Highscore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Victories = table.Column<int>(type: "int", nullable: true),
                    Losses = table.Column<int>(type: "int", nullable: true),
                    UserNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Highscore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Highscore_User_UserNavigationId",
                        column: x => x.UserNavigationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connection_OtherUserNavigationId",
                table: "Connection",
                column: "OtherUserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserNavigationId",
                table: "Connection",
                column: "UserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Highscore_UserNavigationId",
                table: "Highscore",
                column: "UserNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "Highscore");
        }
    }
}
