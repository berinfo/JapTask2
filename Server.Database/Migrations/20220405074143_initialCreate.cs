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
                    PurchaseQuantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
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
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
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
                    { 36, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3933), "Ingredient30", 27m, 3m, 4 },
                    { 35, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3930), "Ingredient29", 26m, 2m, 2 },
                    { 34, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3928), "Ingredient28", 25m, 1m, 2 },
                    { 33, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3925), "Ingredient27", 24m, 1m, 2 },
                    { 28, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3912), "Ingredient22", 10m, 7m, 2 },
                    { 31, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3920), "Ingredient25", 22m, 1m, 2 },
                    { 30, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3917), "Ingredient24", 10m, 9m, 2 },
                    { 29, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3915), "Ingredient23", 10m, 8m, 2 },
                    { 37, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3935), "Ingredient31", 28m, 4m, 4 },
                    { 32, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3922), "Ingredient26", 23m, 1m, 2 },
                    { 38, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3976), "Ingredient32", 10m, 5m, 4 },
                    { 48, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(4001), "Ingredient42", 10m, 1m, 4 },
                    { 40, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3982), "Ingredient34", 12m, 7m, 4 },
                    { 41, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3984), "Ingredient35", 13m, 3m, 4 },
                    { 42, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3987), "Ingredient36", 14m, 1m, 2 },
                    { 43, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3989), "Ingredient37", 15m, 3m, 4 },
                    { 44, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3991), "Ingredient38", 16m, 2m, 4 },
                    { 45, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3994), "Ingredient39", 17m, 1m, 4 },
                    { 46, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3996), "Ingredient40", 18m, 1m, 4 },
                    { 47, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3999), "Ingredient41", 10m, 1m, 4 },
                    { 27, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3910), "Ingredient21", 10m, 6m, 2 },
                    { 49, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(4004), "Ingredient43", 10m, 1m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnit" },
                values: new object[,]
                {
                    { 39, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3979), "Ingredient33", 10m, 6m, 4 },
                    { 26, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3907), "Ingredient20", 10m, 5m, 2 },
                    { 16, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3882), "Ingredient10", 19m, 1m, 2 },
                    { 24, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3903), "Ingredient18", 10m, 3m, 2 },
                    { 1, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(2664), "Oil", 3m, 1m, 4 },
                    { 2, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3832), "Flour", 30m, 25m, 2 },
                    { 3, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3846), "Sugar", 3m, 1m, 2 },
                    { 4, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3849), "Salt", 2m, 1m, 2 },
                    { 5, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3851), "Olive Oil", 20m, 1m, 4 },
                    { 6, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3856), "Egg", 9m, 30m, 0 },
                    { 7, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3859), "Ingredient1", 10m, 1m, 2 },
                    { 8, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3862), "Ingredient2", 11m, 2m, 2 },
                    { 9, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3864), "Ingredient3", 12m, 2m, 2 },
                    { 10, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3868), "Ingredient4", 13m, 2m, 2 },
                    { 11, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3870), "Ingredient5", 14m, 2m, 2 },
                    { 12, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3873), "Ingredient6", 15m, 2m, 2 },
                    { 13, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3875), "Ingredient7", 16m, 2m, 2 },
                    { 14, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3878), "Ingredient8", 17m, 2m, 2 },
                    { 15, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3880), "Ingredient9", 18m, 1m, 2 },
                    { 50, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(4006), "Ingredient44", 10m, 1m, 4 },
                    { 17, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3885), "Ingredient11", 20m, 1m, 2 },
                    { 18, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3888), "Ingredient12", 10m, 1m, 2 },
                    { 19, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3891), "Ingredient13", 10m, 1m, 2 },
                    { 20, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3893), "Ingredient14", 10m, 1m, 2 },
                    { 21, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3895), "Ingredient15", 10m, 1m, 2 },
                    { 22, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3898), "Ingredient16", 10m, 1m, 2 },
                    { 23, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3900), "Ingredient17", 10m, 2m, 2 },
                    { 25, new DateTime(2022, 4, 5, 9, 41, 43, 224, DateTimeKind.Local).AddTicks(3905), "Ingredient19", 10m, 4m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 183, 176, 215, 97, 85, 71, 172, 13, 251, 223, 83, 246, 17, 223, 170, 104, 10, 221, 9, 154, 214, 214, 4, 166, 49, 44, 72, 92, 63, 8, 222, 204, 213, 148, 213, 247, 30, 166, 125, 217, 68, 133, 232, 89, 62, 137, 246, 170, 180, 30, 6, 136, 9, 222, 161, 179, 123, 34, 156, 83, 194, 194, 220, 136 }, new byte[] { 5, 240, 45, 186, 26, 209, 157, 129, 238, 48, 68, 49, 132, 75, 118, 141, 218, 64, 164, 133, 14, 157, 10, 3, 207, 48, 32, 153, 232, 230, 62, 108, 29, 14, 176, 171, 64, 225, 246, 164, 56, 254, 85, 158, 205, 197, 156, 204, 124, 176, 242, 156, 157, 126, 91, 207, 246, 244, 60, 109, 173, 148, 191, 234, 171, 207, 116, 116, 39, 226, 150, 6, 109, 54, 183, 191, 160, 111, 37, 40, 235, 182, 47, 208, 45, 43, 30, 154, 119, 106, 222, 82, 127, 183, 65, 44, 23, 97, 225, 242, 210, 110, 102, 59, 30, 163, 162, 233, 38, 204, 29, 177, 212, 63, 220, 169, 26, 226, 182, 181, 12, 237, 232, 90, 172, 93, 76, 39 }, "user123" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9236), "Description of a recipe whos id is $5", "Naziv recepta 5" },
                    { 29, 12, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9921), "Description of a recipe whos id is $29", "Naziv recepta 29" },
                    { 39, 12, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(215), "Description of a recipe whos id is $39", "Naziv recepta 39" },
                    { 30, 13, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9945), "Description of a recipe whos id is $30", "Naziv recepta 30" },
                    { 11, 14, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9430), "Description of a recipe whos id is $11", "Naziv recepta 11" },
                    { 38, 14, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(191), "Description of a recipe whos id is $38", "Naziv recepta 38" },
                    { 40, 14, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(239), "Description of a recipe whos id is $40", "Naziv recepta 40" },
                    { 31, 15, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9969), "Description of a recipe whos id is $31", "Naziv recepta 31" },
                    { 44, 15, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(333), "Description of a recipe whos id is $44", "Naziv recepta 44" },
                    { 45, 15, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(357), "Description of a recipe whos id is $45", "Naziv recepta 45" },
                    { 47, 15, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(405), "Description of a recipe whos id is $47", "Naziv recepta 47" },
                    { 25, 16, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9826), "Description of a recipe whos id is $25", "Naziv recepta 25" },
                    { 32, 16, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9992), "Description of a recipe whos id is $32", "Naziv recepta 32" },
                    { 42, 16, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(286), "Description of a recipe whos id is $42", "Naziv recepta 42" },
                    { 23, 17, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9779), "Description of a recipe whos id is $23", "Naziv recepta 23" },
                    { 27, 17, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9874), "Description of a recipe whos id is $27", "Naziv recepta 27" },
                    { 33, 17, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(14), "Description of a recipe whos id is $33", "Naziv recepta 33" },
                    { 2, 18, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9160), "Description of a recipe whos id is $2", "Naziv recepta 2" },
                    { 4, 18, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9211), "Description of a recipe whos id is $4", "Naziv recepta 4" },
                    { 8, 18, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9355), "Description of a recipe whos id is $8", "Naziv recepta 8" },
                    { 16, 18, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9549), "Description of a recipe whos id is $16", "Naziv recepta 16" },
                    { 17, 18, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9587), "Description of a recipe whos id is $17", "Naziv recepta 17" },
                    { 12, 12, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9453), "Description of a recipe whos id is $12", "Naziv recepta 12" },
                    { 22, 19, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9755), "Description of a recipe whos id is $22", "Naziv recepta 22" },
                    { 9, 12, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9379), "Description of a recipe whos id is $9", "Naziv recepta 9" },
                    { 20, 10, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9661), "Description of a recipe whos id is $20", "Naziv recepta 20" },
                    { 13, 1, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9477), "Description of a recipe whos id is $13", "Naziv recepta 13" },
                    { 34, 1, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(39), "Description of a recipe whos id is $34", "Naziv recepta 34" },
                    { 41, 1, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(262), "Description of a recipe whos id is $41", "Naziv recepta 41" },
                    { 49, 1, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(451), "Description of a recipe whos id is $49", "Naziv recepta 49" },
                    { 3, 2, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9186), "Description of a recipe whos id is $3", "Naziv recepta 3" },
                    { 10, 2, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9406), "Description of a recipe whos id is $10", "Naziv recepta 10" },
                    { 6, 3, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9263), "Description of a recipe whos id is $6", "Naziv recepta 6" },
                    { 15, 3, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9526), "Description of a recipe whos id is $15", "Naziv recepta 15" },
                    { 24, 3, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9803), "Description of a recipe whos id is $24", "Naziv recepta 24" },
                    { 46, 3, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(381), "Description of a recipe whos id is $46", "Naziv recepta 46" },
                    { 7, 5, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9287), "Description of a recipe whos id is $7", "Naziv recepta 7" },
                    { 28, 5, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9897), "Description of a recipe whos id is $28", "Naziv recepta 28" },
                    { 1, 7, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9097), "Description of a recipe whos id is $1", "Naziv recepta 1" },
                    { 35, 8, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(117), "Description of a recipe whos id is $35", "Naziv recepta 35" },
                    { 36, 8, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(143), "Description of a recipe whos id is $36", "Naziv recepta 36" },
                    { 18, 9, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9612), "Description of a recipe whos id is $18", "Naziv recepta 18" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 21, 9, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9685), "Description of a recipe whos id is $21", "Naziv recepta 21" },
                    { 26, 9, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9850), "Description of a recipe whos id is $26", "Naziv recepta 26" },
                    { 37, 9, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(167), "Description of a recipe whos id is $37", "Naziv recepta 37" },
                    { 14, 10, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9501), "Description of a recipe whos id is $14", "Naziv recepta 14" },
                    { 19, 10, new DateTime(2022, 4, 5, 9, 41, 43, 225, DateTimeKind.Local).AddTicks(9637), "Description of a recipe whos id is $19", "Naziv recepta 19" },
                    { 43, 10, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(309), "Description of a recipe whos id is $43", "Naziv recepta 43" },
                    { 48, 19, new DateTime(2022, 4, 5, 9, 41, 43, 226, DateTimeKind.Local).AddTicks(429), "Description of a recipe whos id is $48", "Naziv recepta 48" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 9, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 13, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 18, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66m, 3 },
                    { 49, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 24, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 189m, 1 },
                    { 8, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 2, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 3, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 19, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124m, 3 },
                    { 18, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 4, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 31, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 285m, 3 },
                    { 26, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169m, 3 },
                    { 10, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197m, 3 },
                    { 17, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 13, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 40, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 21, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 216m, 3 },
                    { 30, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 23, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 401m, 1 },
                    { 40, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 463m, 1 },
                    { 17, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 447m, 1 },
                    { 26, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 48, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 371m, 1 },
                    { 31, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71m, 1 },
                    { 6, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 8, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 19, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 38, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 346m, 3 },
                    { 14, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 241m, 3 },
                    { 23, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 220m, 1 },
                    { 7, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 22, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 301m, 3 },
                    { 36, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 394m, 3 },
                    { 38, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 163m, 3 },
                    { 22, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 2, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107m, 3 },
                    { 41, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 38, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 7, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 422m, 3 },
                    { 37, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m, 3 },
                    { 10, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 498m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 42, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 34, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 390m, 1 },
                    { 41, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 11, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 5, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 48, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 28, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, 1 },
                    { 42, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 375m, 3 },
                    { 37, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 164m, 3 },
                    { 6, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 342m, 3 },
                    { 38, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 30, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66m, 1 },
                    { 28, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 28, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 23, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 42, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101m, 1 },
                    { 33, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 18, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 296m, 3 },
                    { 27, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 24, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 18, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 35, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 29, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 4, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 159m, 1 },
                    { 36, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 362m, 1 },
                    { 12, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 46, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 37, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 256m, 1 },
                    { 17, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198m, 3 },
                    { 3, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 218m, 3 },
                    { 15, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 32, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 41, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 29, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 20, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 37, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 424m, 3 },
                    { 32, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 20, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 262m, 1 },
                    { 14, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 37, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 191m, 3 },
                    { 18, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 21, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 46, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 40, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175m, 3 },
                    { 32, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108m, 1 },
                    { 7, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77m, 1 },
                    { 48, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 121m, 1 },
                    { 32, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 230m, 1 },
                    { 15, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 436m, 1 },
                    { 8, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 473m, 1 },
                    { 19, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 25, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 17, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 221m, 1 },
                    { 24, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 351m, 1 },
                    { 49, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 43, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 274m, 3 },
                    { 39, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 334m, 3 },
                    { 7, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 37, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 41, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 42, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 369m, 3 },
                    { 32, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 265m, 3 },
                    { 17, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 264m, 1 },
                    { 2, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53m, 1 },
                    { 28, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 11, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 49, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 4, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 24, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 49, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 34, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 12, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 7, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 35, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 322m, 1 },
                    { 37, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 320m, 3 },
                    { 5, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 1, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 19, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 494m, 3 },
                    { 14, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 245m, 1 },
                    { 31, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, 1 },
                    { 15, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 22, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 296m, 3 },
                    { 47, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 46, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 27, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 45, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 23, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 43, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 365m, 1 },
                    { 15, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 447m, 1 },
                    { 31, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 388m, 3 },
                    { 43, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 23, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 321m, 1 },
                    { 12, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 19, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 262m, 1 },
                    { 13, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 374m, 3 },
                    { 22, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 332m, 3 },
                    { 37, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 },
                    { 9, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 7, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 23, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89m, 3 },
                    { 33, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 5, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 2, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 136m, 1 },
                    { 43, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 324m, 1 },
                    { 46, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 446m, 1 },
                    { 24, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 33, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 26, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 253m, 1 },
                    { 48, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 119m, 1 },
                    { 8, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 6, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53m, 3 },
                    { 37, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 294m, 1 },
                    { 14, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 4 },
                    { 13, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 347m, 3 },
                    { 7, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 3, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 18, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 2 },
                    { 24, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 239m, 3 },
                    { 47, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 459m, 3 },
                    { 17, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 34, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204m, 1 },
                    { 24, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4 },
                    { 49, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 13, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 149m, 3 },
                    { 41, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 6, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 4 },
                    { 12, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 1, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 4 },
                    { 40, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 444m, 3 },
                    { 17, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 41, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 23, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 268m, 1 },
                    { 26, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 163m, 1 },
                    { 20, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 403m, 1 },
                    { 21, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2 },
                    { 39, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 411m, 1 },
                    { 5, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 403m, 1 },
                    { 3, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 2 },
                    { 15, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 297m, 1 },
                    { 5, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 225m, 1 },
                    { 7, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 427m, 1 },
                    { 37, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 453m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            var calculateFunction = @"CREATE FUNCTION [dbo].[CalculateTotalCosts]
             (
                @recipesIngredientQuantity decimal
              , @ingredientPurchasedPrice decimal
              , @ingredientPurchasedQuantity decimal
              , @ingredientUnit int
              , @recipesIngredientUnit int
             )
            RETURNS float
            AS
            BEGIN
            DECLARE @TotalCost float;
            SELECT @TotalCost = CASE

            WHEN @ingredientUnit = 1 and @recipesIngredientUnit = 1 or @ingredientUnit = 3 and @recipesIngredientUnit = 3 or @ingredientUnit = 1 and @recipesIngredientUnit = 3
            THEN
            (@recipesIngredientQuantity / 1000) * (@ingredientPurchasedPrice / (@ingredientPurchasedQuantity / 1000))

            WHEN @recipesIngredientUnit = 1 OR @recipesIngredientUnit = 3
            THEN
            (@recipesIngredientQuantity / 1000) * (@ingredientPurchasedPrice / (@ingredientPurchasedQuantity))

            WHEN @ingredientUnit = 1 OR @ingredientUnit = 3
            THEN
            (@recipesIngredientQuantity ) * (@ingredientPurchasedPrice / (@ingredientPurchasedQuantity / 1000))

            ELSE
            @recipesIngredientQuantity * (@ingredientPurchasedPrice / @ingredientPurchasedQuantity)
            END
            RETURN @TotalCost
            END";

            var spGetMostUsedINgredients = @"CREATE PROCEDURE [dbo].[GetMostUsedINgredients]
            (
	            @MinQuant AS DECIMAL,
	            @MaxQuant AS DECIMAL,
	            @MeasureType as INT
            )
            AS
            BEGIN
	            SELECT TOP 10 Ingredients.Name, COUNT(Ingredients.Id) AS Used_Count FROM Ingredients
	            INNER JOIN RecipeIngredients
	            ON RecipeIngredients.IngredientId = Ingredients.Id
	            WHERE RecipeIngredients.Quantity >= @MinQuant AND
		              RecipeIngredients.Quantity <= @MaxQuant AND
		              RecipeIngredients.Unit = @MeasureType
	            GROUP BY  Ingredients.Name
	            ORDER BY Used_Count DESC
            END";

            var spGetRecipesByCategory = @"CREATE PROC [dbo].[GetRecipesByCategory]
            AS
            BEGIN

            SELECT Categories.Name AS Category_Name, Recipes.Name AS Recipe_Name, SUM(dbo.CalculateTotalCosts(RecipeIngredients.Quantity, Ingredients.PurchasePrice, Ingredients.PurchaseQuantity,Ingredients.PurchaseUnit,RecipeIngredients.Unit)) AS TotalPrice FROM RecipeIngredients
            INNER JOIN Recipes
            ON Recipes.Id = RecipeIngredients.RecipeId
            INNER JOIN Ingredients
            ON Ingredients.Id = RecipeIngredients.IngredientId
            INNER JOIN Categories
            ON Recipes.CategoryId = Categories.Id
            GROUP BY Categories.Name, Recipes.Name
            ORDER BY TotalPrice DESC
            END";

            var spGetRecipesWith6orMoreIngredients = @"CREATE PROCEDURE [dbo].[spGet_Recipes_With_6orMore_Ingredients]
            AS 
            BEGIN
            SELECT Recipes.Id, Recipes.Name,
            SUM(dbo.CalculateTotalCosts(RecipeIngredients.Quantity, Ingredients.PurchasePrice, Ingredients.PurchaseQuantity,Ingredients.PurchaseUnit,RecipeIngredients.Unit)) as TotalPrice,
            COUNT(RecipeIngredients.IngredientId) AS TotalIngredientsNumber
            FROM Ingredients
            INNER JOIN RecipeIngredients
            ON RecipeIngredients.IngredientId = Ingredients.Id
            INNER JOIN Recipes
            ON Recipes.Id = RecipeIngredients.RecipeId
            GROUP BY Recipes.Name, Recipes.Id
            HAVING COUNT(RecipeIngredients.IngredientId) > 5
            ORDER BY TotalPrice DESC
            END";

            migrationBuilder.Sql(calculateFunction);
            migrationBuilder.Sql(spGetMostUsedINgredients);
            migrationBuilder.Sql(spGetRecipesByCategory);
            migrationBuilder.Sql(spGetRecipesWith6orMoreIngredients);
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
