using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Recipe_RecipeId",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_RecipeId",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Tag name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagResourceId",
                schema: "dbo",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Public unique identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                schema: "dbo",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Name of the ingredient",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "FK to Recipe that the Ingredient belongs to");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Description of the ingredient");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientResourceId",
                schema: "dbo",
                table: "Ingredient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Public unique identifier");

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                schema: "dbo",
                columns: table => new
                {
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeIngredientResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Public unique identifier"),
                    RecipeId = table.Column<int>(type: "int", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.RecipeIngredientId);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "dbo",
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "RecipeId");
                });

            migrationBuilder.CreateTable(
                name: "RecipeTag",
                schema: "dbo",
                columns: table => new
                {
                    RecipeTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeTagResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Public unique identifier"),
                    RecipeId = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTag", x => x.RecipeTagId);
                    table.ForeignKey(
                        name: "FK_RecipeTag_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dbo",
                        principalTable: "Recipe",
                        principalColumn: "RecipeId");
                    table.ForeignKey(
                        name: "FK_RecipeTag_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tags",
                        principalColumn: "TagId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_RecipeId",
                schema: "dbo",
                table: "RecipeTag",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_TagId",
                schema: "dbo",
                table: "RecipeTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecipeTag",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "TagResourceId",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "IngredientResourceId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Tag name");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                schema: "dbo",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Recipe",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: true,
                comment: "FK to Recipe that the Ingredient belongs to",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Name of the ingredient");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_RecipeId",
                schema: "dbo",
                table: "Tags",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                schema: "dbo",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                schema: "dbo",
                table: "Ingredient",
                column: "RecipeId",
                principalSchema: "dbo",
                principalTable: "Recipe",
                principalColumn: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Recipe_RecipeId",
                schema: "dbo",
                table: "Tags",
                column: "RecipeId",
                principalSchema: "dbo",
                principalTable: "Recipe",
                principalColumn: "RecipeId");
        }
    }
}
