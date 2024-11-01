using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PiecesOfArt_Application_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loyaltyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyaltyCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LoyaltyCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_loyaltyCards_LoyaltyCardId",
                        column: x => x.LoyaltyCardId,
                        principalTable: "loyaltyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pieceOfArts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublicatioDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pieceOfArts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pieceOfArts_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pieceOfArts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A 19th-century art movement characterized by small, thin brush strokes and emphasis on light and movement.", "Impressionism" },
                    { 2, "A period in European history marking the revival of classical learning and wisdom.", "Renaissance" },
                    { 3, "Art that uses shapes, colors, forms, and gestural marks to achieve its effect rather than depicting objects.", "Abstract" },
                    { 4, "A broad category that reflects artistic work produced during the late 19th to mid-20th century.", "Modern" },
                    { 5, "Art from ancient civilizations, including Egyptian, Mesopotamian, and classical Greek.", "Ancient" }
                });

            migrationBuilder.InsertData(
                table: "loyaltyCards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "10% Off", "Bronze" },
                    { 2, "20% Off", "Silver" },
                    { 3, "30% Off", "Gold" },
                    { 4, "40% Off", "Platinum" },
                    { 5, "50% Off", "Crystal" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Age", "Email", "LoyaltyCardId", "Name" },
                values: new object[,]
                {
                    { 1, 30, "john@example.com", 1, "John Doe" },
                    { 2, 28, "jane@example.com", 2, "Jane Smith" },
                    { 3, 35, "emily@example.com", 3, "Emily Johnson" },
                    { 4, 40, "michael@example.com", 4, "Michael Brown" },
                    { 5, 25, "david@example.com", 5, "David Williams" }
                });

            migrationBuilder.InsertData(
                table: "pieceOfArts",
                columns: new[] { "Id", "CategoryId", "Price", "PublicatioDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 100000.0, new DateOnly(1889, 6, 1), "Starry Night", 1 },
                    { 2, 2, 500000.0, new DateOnly(1503, 10, 1), "The Mona Lisa", 2 },
                    { 3, 3, 120000.0, new DateOnly(1923, 7, 1), "Composition VIII", 3 },
                    { 4, 4, 200000.0, new DateOnly(1931, 5, 1), "The Persistence of Memory", 4 },
                    { 5, 5, 150000.0, new DateOnly(1400, 1, 1), "Small Pyramid", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pieceOfArts_CategoryId",
                table: "pieceOfArts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_pieceOfArts_UserId",
                table: "pieceOfArts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_LoyaltyCardId",
                table: "users",
                column: "LoyaltyCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pieceOfArts");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "loyaltyCards");
        }
    }
}
