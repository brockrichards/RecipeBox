using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Units_UnitId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Tags_TagId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                schema: "dbo",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                schema: "dbo",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Units",
                schema: "dbo",
                newName: "Unit",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Tags",
                schema: "dbo",
                newName: "Tag",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Units_LastModifiedSubjectId",
                schema: "dbo",
                table: "Unit",
                newName: "IX_Unit_LastModifiedSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_CreatedSubjectId",
                schema: "dbo",
                table: "Unit",
                newName: "IX_Unit_CreatedSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_LastModifiedSubjectId",
                schema: "dbo",
                table: "Tag",
                newName: "IX_Tag_LastModifiedSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_CreatedSubjectId",
                schema: "dbo",
                table: "Tag",
                newName: "IX_Tag_CreatedSubjectId");

            migrationBuilder.AlterTable(
                name: "Unit",
                schema: "dbo",
                comment: "Units of measurement for Ingredients");

            migrationBuilder.AlterTable(
                name: "Tag",
                schema: "dbo",
                comment: "Tags for organizing recipes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                schema: "dbo",
                table: "Unit",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                schema: "dbo",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Unit_UnitId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "UnitId",
                principalSchema: "dbo",
                principalTable: "Unit",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Tag_TagId",
                schema: "dbo",
                table: "RecipeTag",
                column: "TagId",
                principalSchema: "dbo",
                principalTable: "Tag",
                principalColumn: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Tag",
                column: "CreatedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Tag",
                column: "LastModifiedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Unit",
                column: "CreatedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Unit",
                column: "LastModifiedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Unit_UnitId",
                schema: "dbo",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Tag_TagId",
                schema: "dbo",
                table: "RecipeTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                schema: "dbo",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                schema: "dbo",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Unit",
                schema: "dbo",
                newName: "Units",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Tag",
                schema: "dbo",
                newName: "Tags",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_LastModifiedSubjectId",
                schema: "dbo",
                table: "Units",
                newName: "IX_Units_LastModifiedSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_CreatedSubjectId",
                schema: "dbo",
                table: "Units",
                newName: "IX_Units_CreatedSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_LastModifiedSubjectId",
                schema: "dbo",
                table: "Tags",
                newName: "IX_Tags_LastModifiedSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_CreatedSubjectId",
                schema: "dbo",
                table: "Tags",
                newName: "IX_Tags_CreatedSubjectId");

            migrationBuilder.AlterTable(
                name: "Units",
                schema: "dbo",
                oldComment: "Units of measurement for Ingredients");

            migrationBuilder.AlterTable(
                name: "Tags",
                schema: "dbo",
                oldComment: "Tags for organizing recipes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                schema: "dbo",
                table: "Units",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                schema: "dbo",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Units_UnitId",
                schema: "dbo",
                table: "RecipeIngredient",
                column: "UnitId",
                principalSchema: "dbo",
                principalTable: "Units",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Tags_TagId",
                schema: "dbo",
                table: "RecipeTag",
                column: "TagId",
                principalSchema: "dbo",
                principalTable: "Tags",
                principalColumn: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Tags",
                column: "CreatedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Tags",
                column: "LastModifiedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Subject_CreatedSubjectId",
                schema: "dbo",
                table: "Units",
                column: "CreatedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Subject_LastModifiedSubjectId",
                schema: "dbo",
                table: "Units",
                column: "LastModifiedSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }
    }
}
