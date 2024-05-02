using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trello.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visibility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lists_boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "boards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lists_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "newDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newDescriptions_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "opens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_opens_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cards_ListId",
                table: "cards",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_lists_BoardId",
                table: "lists",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_lists_CardId",
                table: "lists",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_newDescriptions_CardId",
                table: "newDescriptions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_opens_CardId",
                table: "opens",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_lists_ListId",
                table: "cards",
                column: "ListId",
                principalTable: "lists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_lists_ListId",
                table: "cards");

            migrationBuilder.DropTable(
                name: "newDescriptions");

            migrationBuilder.DropTable(
                name: "opens");

            migrationBuilder.DropTable(
                name: "registers");

            migrationBuilder.DropTable(
                name: "lists");

            migrationBuilder.DropTable(
                name: "boards");

            migrationBuilder.DropTable(
                name: "cards");
        }
    }
}
