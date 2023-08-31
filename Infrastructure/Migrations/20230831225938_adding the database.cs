using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingthedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 31, 15, 59, 38, 334, DateTimeKind.Local).AddTicks(6373))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "This is the best recipe that you can find"),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 31, 15, 59, 38, 333, DateTimeKind.Local).AddTicks(8506))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipes_users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    ingredient_add_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 31, 15, 59, 38, 333, DateTimeKind.Local).AddTicks(6087))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredients_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recipe_rate = table.Column<byte>(type: "tinyint", nullable: false),
                    IsRemoved = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    rate_confirmed_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 31, 15, 59, 38, 334, DateTimeKind.Local).AddTicks(2285))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ratings_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "IsActive", "Password", "Username" },
                values: new object[] { 1000, "ZGVmQGRlZmF1bHQuZGVmYXVsdA==", "Active", "default123", "default user" });

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_RecipeId",
                table: "ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_RecipeId",
                table: "ratings",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_UserId",
                table: "ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_AuthorId",
                table: "recipes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Username",
                table: "users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
