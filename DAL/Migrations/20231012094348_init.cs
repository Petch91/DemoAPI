using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "gameGenres",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameGenres", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_gameGenres_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_gameGenres_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "GenreId");
                });

            migrationBuilder.CreateTable(
                name: "gameUsers",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameUsers", x => new { x.UserID, x.GameId });
                    table.ForeignKey(
                        name: "FK_gameUsers_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameUsers_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "games",
                columns: new[] { "GameId", "Resume", "Title" },
                values: new object[,]
                {
                    { 1, "Best Game", "FF9" },
                    { 2, "manque un truc", "FF16" },
                    { 3, "Best TPS Game", "Uncharted" },
                    { 4, "Best Action Game", "God Of War" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "Label" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "RPG" },
                    { 3, "TPS" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "PasswordHash", "RoleId", "UserName" },
                values: new object[] { 1, "admin@gmail.com", "$2a$11$kh3Vcrjf8w3n9e63ZOeTf.rTYWaqcouPnQHayS2dRjt4bs9siaNMG", 3, "Admin" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "PasswordHash", "UserName" },
                values: new object[] { 2, "petch@gmail.com", "$2a$11$sMpXEaApZ4Cwk1SppBrEWegwcDgweq30xBg/sLoGsFVZM3DBOApYO", "Petch" });

            migrationBuilder.InsertData(
                table: "gameGenres",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_gameGenres_GenreId",
                table: "gameGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_gameUsers_GameId",
                table: "gameUsers",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gameGenres");

            migrationBuilder.DropTable(
                name: "gameUsers");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
