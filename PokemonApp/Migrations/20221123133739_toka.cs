using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonApp.Migrations
{
    public partial class toka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PokemonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonCard_User_UserNavigationId",
                        column: x => x.UserNavigationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCard_UserNavigationId",
                table: "PokemonCard",
                column: "UserNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCard");
        }
    }
}
