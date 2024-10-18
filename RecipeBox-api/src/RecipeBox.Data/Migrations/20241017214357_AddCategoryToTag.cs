using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropIndex(
                name: "IX_RecipeTag_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropIndex(
                name: "IX_RecipeTag_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "CreatedSubjectId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "CreatedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                schema: "dbo",
                table: "Ingredient");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "dbo",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Tag category");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                schema: "dbo",
                table: "RecipeIngredient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "dbo",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Public unique identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Unit name"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time entity was created"),
                    CreatedSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time entity was last modified"),
                    LastModifiedSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_Subject_CreatedSubjectId",
                        column: x => x.CreatedSubjectId,
                        principalSchema: "dbo",
                        principalTable: "Subject",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Units_Subject_LastModifiedSubjectId",
                        column: x => x.LastModifiedSubjectId,
                        principalSchema: "dbo",
                        principalTable: "Subject",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_UnitId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CreatedSubjectId",
                schema: "dbo",
                table: "Units",
                column: "CreatedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_LastModifiedSubjectId",
                schema: "dbo",
                table: "Units",
                column: "LastModifiedSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Units_UnitId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "UnitId",
                principalSchema: "dbo",
                principalTable: "Units",
                principalColumn: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Units_UnitId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_UnitId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UnitId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "RecipeTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time entity was created");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedSubjectId",
                schema: "dbo",
                table: "RecipeTag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "RecipeTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time entity was last modified");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeTag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "RecipeIngredient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time entity was created");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "RecipeIngredient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time entity was last modified");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                schema: "dbo",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "FK to Recipe that the Ingredient belongs to");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeTag",
                column: "CreatedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeTag",
                column: "LastModifiedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "CreatedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "LastModifiedSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "CreatedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "LastModifiedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "RecipeTag",
                column: "CreatedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "RecipeTag",
                column: "LastModifiedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }
    }
}
