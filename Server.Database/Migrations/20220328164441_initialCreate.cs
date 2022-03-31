using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Database.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PurchaseQuantity = table.Column<int>(type: "int", maxLength: 1000, nullable: false),
                    PurchasePrice = table.Column<float>(type: "real", maxLength: 1000, nullable: false),
                    PurchaseUnit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 1000, nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 3, 5, 25, 4, 0, DateTimeKind.Unspecified), "Category1" },
                    { 20, new DateTime(2017, 6, 9, 1, 21, 15, 0, DateTimeKind.Unspecified), "Category20" },
                    { 19, new DateTime(2017, 6, 8, 1, 20, 15, 0, DateTimeKind.Unspecified), "Category19" },
                    { 18, new DateTime(2017, 6, 9, 1, 19, 15, 0, DateTimeKind.Unspecified), "Category18" },
                    { 17, new DateTime(2017, 6, 8, 1, 18, 15, 0, DateTimeKind.Unspecified), "Category17" },
                    { 15, new DateTime(2017, 6, 8, 1, 16, 15, 0, DateTimeKind.Unspecified), "Category15" },
                    { 14, new DateTime(2017, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category14" },
                    { 13, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category13" },
                    { 12, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category12" },
                    { 11, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category11" },
                    { 16, new DateTime(2017, 6, 9, 1, 17, 15, 0, DateTimeKind.Unspecified), "Category16" },
                    { 9, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category9" },
                    { 8, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category8" },
                    { 7, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category7" },
                    { 6, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category6" },
                    { 5, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category5" },
                    { 4, new DateTime(2019, 5, 6, 2, 2, 2, 0, DateTimeKind.Unspecified), "Category4" },
                    { 3, new DateTime(2020, 4, 6, 3, 17, 25, 0, DateTimeKind.Unspecified), "Category3" },
                    { 2, new DateTime(2021, 4, 4, 6, 15, 14, 0, DateTimeKind.Unspecified), "Category2" },
                    { 10, new DateTime(2018, 5, 7, 1, 15, 15, 0, DateTimeKind.Unspecified), "Category10" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnit" },
                values: new object[,]
                {
                    { 36, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6067), "Ingredient30", 27f, 3, 4 },
                    { 35, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6064), "Ingredient29", 26f, 2, 2 },
                    { 34, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6061), "Ingredient28", 25f, 1, 2 },
                    { 33, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6017), "Ingredient27", 24f, 1, 2 },
                    { 28, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6004), "Ingredient22", 10f, 7, 2 },
                    { 31, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6012), "Ingredient25", 22f, 1, 2 },
                    { 30, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6009), "Ingredient24", 10f, 9, 2 },
                    { 29, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6007), "Ingredient23", 10f, 8, 2 },
                    { 37, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6069), "Ingredient31", 28f, 4, 4 },
                    { 32, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6014), "Ingredient26", 23f, 1, 2 },
                    { 38, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6071), "Ingredient32", 10f, 5, 4 },
                    { 48, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6096), "Ingredient42", 10f, 1, 4 },
                    { 40, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6076), "Ingredient34", 12f, 7, 4 },
                    { 41, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6078), "Ingredient35", 13f, 3, 4 },
                    { 42, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6081), "Ingredient36", 14f, 1, 2 },
                    { 43, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6083), "Ingredient37", 15f, 3, 4 },
                    { 44, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6086), "Ingredient38", 16f, 2, 4 },
                    { 45, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6089), "Ingredient39", 17f, 1, 4 },
                    { 46, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6091), "Ingredient40", 18f, 1, 4 },
                    { 47, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6093), "Ingredient41", 10f, 1, 4 },
                    { 27, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6002), "Ingredient21", 10f, 6, 2 },
                    { 49, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6098), "Ingredient43", 10f, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnit" },
                values: new object[,]
                {
                    { 39, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6074), "Ingredient33", 10f, 6, 4 },
                    { 26, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5999), "Ingredient20", 10f, 5, 2 },
                    { 16, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5973), "Ingredient10", 19f, 1, 2 },
                    { 24, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5994), "Ingredient18", 10f, 3, 2 },
                    { 1, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(4655), "Oil", 3f, 1, 4 },
                    { 2, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5920), "Flour", 30f, 25, 2 },
                    { 3, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5935), "Sugar", 3f, 1, 2 },
                    { 4, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5938), "Salt", 2f, 1, 2 },
                    { 5, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5941), "Olive Oil", 20f, 1, 4 },
                    { 6, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5946), "Egg", 9f, 30, 0 },
                    { 7, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5949), "Ingredient1", 10f, 1, 2 },
                    { 8, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5952), "Ingredient2", 11f, 2, 2 },
                    { 9, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5954), "Ingredient3", 12f, 2, 2 },
                    { 10, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5958), "Ingredient4", 13f, 2, 2 },
                    { 11, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5961), "Ingredient5", 14f, 2, 2 },
                    { 12, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5963), "Ingredient6", 15f, 2, 2 },
                    { 13, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5966), "Ingredient7", 16f, 2, 2 },
                    { 14, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5968), "Ingredient8", 17f, 2, 2 },
                    { 15, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5971), "Ingredient9", 18f, 1, 2 },
                    { 50, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(6101), "Ingredient44", 10f, 1, 4 },
                    { 17, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5976), "Ingredient11", 20f, 1, 2 },
                    { 18, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5979), "Ingredient12", 10f, 1, 2 },
                    { 19, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5982), "Ingredient13", 10f, 1, 2 },
                    { 20, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5984), "Ingredient14", 10f, 1, 2 },
                    { 21, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5987), "Ingredient15", 10f, 1, 2 },
                    { 22, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5989), "Ingredient16", 10f, 1, 2 },
                    { 23, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5992), "Ingredient17", 10f, 2, 2 },
                    { 25, new DateTime(2022, 3, 28, 18, 44, 41, 439, DateTimeKind.Local).AddTicks(5997), "Ingredient19", 10f, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 53, 148, 16, 107, 74, 60, 218, 227, 244, 146, 166, 18, 239, 25, 9, 9, 33, 120, 88, 212, 233, 82, 61, 107, 51, 65, 55, 222, 34, 136, 192, 129, 23, 196, 89, 55, 110, 12, 248, 63, 54, 24, 241, 174, 244, 7, 196, 162, 164, 210, 88, 49, 210, 131, 109, 186, 135, 44, 142, 79, 92, 185, 96, 220 }, new byte[] { 14, 251, 164, 213, 65, 179, 191, 76, 118, 87, 241, 248, 52, 55, 76, 241, 192, 106, 215, 26, 136, 115, 34, 85, 2, 135, 167, 206, 165, 134, 213, 62, 62, 8, 32, 155, 54, 9, 31, 153, 63, 46, 183, 211, 77, 47, 222, 6, 54, 196, 169, 52, 207, 22, 48, 2, 3, 216, 221, 118, 124, 148, 5, 87, 228, 157, 230, 186, 123, 56, 130, 106, 215, 54, 97, 130, 243, 253, 61, 29, 67, 10, 34, 35, 23, 149, 35, 87, 94, 98, 252, 225, 211, 206, 156, 164, 202, 209, 219, 225, 234, 221, 229, 166, 243, 235, 90, 87, 153, 17, 10, 187, 27, 31, 253, 203, 71, 250, 209, 245, 184, 221, 118, 19, 204, 216, 64, 159 }, "user123" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 36, 1, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2245), "Description of a recipe whos id is $36", "Naziv recepta 36" },
                    { 20, 13, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1793), "Description of a recipe whos id is $20", "Naziv recepta 20" },
                    { 27, 13, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1998), "Description of a recipe whos id is $27", "Naziv recepta 27" },
                    { 34, 13, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2169), "Description of a recipe whos id is $34", "Naziv recepta 34" },
                    { 8, 14, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1490), "Description of a recipe whos id is $8", "Naziv recepta 8" },
                    { 11, 14, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1568), "Description of a recipe whos id is $11", "Naziv recepta 11" },
                    { 13, 14, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1617), "Description of a recipe whos id is $13", "Naziv recepta 13" },
                    { 43, 14, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2412), "Description of a recipe whos id is $43", "Naziv recepta 43" },
                    { 15, 15, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1667), "Description of a recipe whos id is $15", "Naziv recepta 15" },
                    { 26, 15, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1973), "Description of a recipe whos id is $26", "Naziv recepta 26" },
                    { 32, 15, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2119), "Description of a recipe whos id is $32", "Naziv recepta 32" },
                    { 4, 16, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1322), "Description of a recipe whos id is $4", "Naziv recepta 4" },
                    { 16, 17, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1694), "Description of a recipe whos id is $16", "Naziv recepta 16" },
                    { 21, 17, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1818), "Description of a recipe whos id is $21", "Naziv recepta 21" },
                    { 2, 18, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1269), "Description of a recipe whos id is $2", "Naziv recepta 2" },
                    { 7, 18, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1399), "Description of a recipe whos id is $7", "Naziv recepta 7" },
                    { 30, 18, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2070), "Description of a recipe whos id is $30", "Naziv recepta 30" },
                    { 39, 18, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2316), "Description of a recipe whos id is $39", "Naziv recepta 39" },
                    { 41, 18, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2364), "Description of a recipe whos id is $41", "Naziv recepta 41" },
                    { 48, 18, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2531), "Description of a recipe whos id is $48", "Naziv recepta 48" },
                    { 6, 19, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1375), "Description of a recipe whos id is $6", "Naziv recepta 6" },
                    { 17, 19, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1718), "Description of a recipe whos id is $17", "Naziv recepta 17" },
                    { 33, 12, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2144), "Description of a recipe whos id is $33", "Naziv recepta 33" },
                    { 46, 19, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2483), "Description of a recipe whos id is $46", "Naziv recepta 46" },
                    { 29, 12, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2047), "Description of a recipe whos id is $29", "Naziv recepta 29" },
                    { 44, 11, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2435), "Description of a recipe whos id is $44", "Naziv recepta 44" },
                    { 12, 2, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1592), "Description of a recipe whos id is $12", "Naziv recepta 12" },
                    { 38, 2, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2293), "Description of a recipe whos id is $38", "Naziv recepta 38" },
                    { 40, 2, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2340), "Description of a recipe whos id is $40", "Naziv recepta 40" },
                    { 42, 2, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2388), "Description of a recipe whos id is $42", "Naziv recepta 42" },
                    { 45, 2, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2458), "Description of a recipe whos id is $45", "Naziv recepta 45" },
                    { 47, 2, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2506), "Description of a recipe whos id is $47", "Naziv recepta 47" },
                    { 3, 3, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1297), "Description of a recipe whos id is $3", "Naziv recepta 3" },
                    { 24, 4, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1923), "Description of a recipe whos id is $24", "Naziv recepta 24" },
                    { 23, 5, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1898), "Description of a recipe whos id is $23", "Naziv recepta 23" },
                    { 18, 6, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1743), "Description of a recipe whos id is $18", "Naziv recepta 18" },
                    { 19, 7, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1767), "Description of a recipe whos id is $19", "Naziv recepta 19" },
                    { 22, 7, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1874), "Description of a recipe whos id is $22", "Naziv recepta 22" },
                    { 1, 8, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1205), "Description of a recipe whos id is $1", "Naziv recepta 1" },
                    { 10, 8, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1543), "Description of a recipe whos id is $10", "Naziv recepta 10" },
                    { 31, 8, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2095), "Description of a recipe whos id is $31", "Naziv recepta 31" },
                    { 35, 8, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2193), "Description of a recipe whos id is $35", "Naziv recepta 35" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 14, 9, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1642), "Description of a recipe whos id is $14", "Naziv recepta 14" },
                    { 28, 9, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2022), "Description of a recipe whos id is $28", "Naziv recepta 28" },
                    { 25, 10, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1949), "Description of a recipe whos id is $25", "Naziv recepta 25" },
                    { 37, 10, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2269), "Description of a recipe whos id is $37", "Naziv recepta 37" },
                    { 5, 11, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1347), "Description of a recipe whos id is $5", "Naziv recepta 5" },
                    { 9, 12, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(1516), "Description of a recipe whos id is $9", "Naziv recepta 9" },
                    { 49, 19, new DateTime(2022, 3, 28, 18, 44, 41, 441, DateTimeKind.Local).AddTicks(2554), "Description of a recipe whos id is $49", "Naziv recepta 49" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 27, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 48, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 3 },
                    { 28, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 241, 3 },
                    { 49, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 356, 3 },
                    { 20, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 41, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 31, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 20, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 191, 1 },
                    { 33, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 117, 1 },
                    { 18, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 27, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 8, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 370, 3 },
                    { 40, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 24, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 7, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 14, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 293, 1 },
                    { 13, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 363, 1 },
                    { 5, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 15, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 478, 1 },
                    { 26, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 24, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 34, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 20, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 26, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 272, 3 },
                    { 17, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 407, 1 },
                    { 21, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 22, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 35, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 1 },
                    { 34, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 11, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 1 },
                    { 44, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 261, 1 },
                    { 19, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 436, 1 },
                    { 16, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 3 },
                    { 16, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 35, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 38, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 30, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 46, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 21, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 22, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 48, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 16, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 8, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 7, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 157, 3 },
                    { 4, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 44, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 3 },
                    { 32, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 42, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 41, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 36, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 272, 3 },
                    { 20, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 16, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 46, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 370, 1 },
                    { 35, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 28, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 36, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 363, 3 },
                    { 35, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 3 },
                    { 35, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 1 },
                    { 48, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 49, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 37, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 11, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 309, 3 },
                    { 48, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 49, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 15, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 341, 3 },
                    { 44, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 487, 1 },
                    { 24, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 40, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 1 },
                    { 40, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 494, 3 },
                    { 43, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 28, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 151, 1 },
                    { 44, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 309, 1 },
                    { 43, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 11, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 3 },
                    { 39, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 24, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 29, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 25, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 156, 3 },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 33, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 37, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 337, 3 },
                    { 11, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 37, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 395, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 47, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 148, 1 },
                    { 7, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 18, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 42, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 1 },
                    { 43, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 3, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 8, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 311, 3 },
                    { 34, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 320, 1 },
                    { 27, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 19, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 429, 1 },
                    { 30, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 1 },
                    { 39, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 22, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 8, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 26, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 1 },
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 450, 3 },
                    { 30, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 3 },
                    { 22, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1 },
                    { 41, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 4, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 48, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 460, 3 },
                    { 11, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 28, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 1 },
                    { 43, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 36, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 7, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 39, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 134, 3 },
                    { 32, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 117, 3 },
                    { 45, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 261, 1 },
                    { 23, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 1 },
                    { 47, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 499, 3 },
                    { 21, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 25, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 370, 1 },
                    { 35, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 37, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 3 },
                    { 19, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 464, 3 },
                    { 17, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 309, 1 },
                    { 39, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 372, 1 },
                    { 14, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 136, 3 },
                    { 38, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 35, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 153, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 4, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 356, 1 },
                    { 6, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 26, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 439, 3 },
                    { 37, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 3 },
                    { 9, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 248, 1 },
                    { 21, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 48, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, 3 },
                    { 49, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 3 },
                    { 45, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 14, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 3 },
                    { 10, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1 },
                    { 44, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 160, 3 },
                    { 16, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 233, 3 },
                    { 30, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 287, 1 },
                    { 43, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 14, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 13, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 7, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 442, 3 },
                    { 19, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 43, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 1 },
                    { 12, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 39, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 44, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 345, 3 },
                    { 23, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 499, 3 },
                    { 30, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 471, 1 },
                    { 33, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 440, 1 },
                    { 31, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 378, 3 },
                    { 3, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 42, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 13, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 255, 1 },
                    { 4, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 22, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 5, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 190, 1 },
                    { 35, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 225, 3 },
                    { 2, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 11, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 306, 1 },
                    { 12, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 456, 1 },
                    { 14, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 42, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 28, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 1 },
                    { 31, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 21, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 13, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 3 },
                    { 23, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 3 },
                    { 49, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 48, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 8, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 237, 1 },
                    { 3, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 233, 1 },
                    { 13, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 16, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 37, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 43, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 29, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 356, 3 },
                    { 4, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 37, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 47, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 153, 1 },
                    { 32, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 462, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
