using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAuditableEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedSubjectSubjectId",
                schema: "dbo",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedSubjectSubjectId",
                schema: "dbo",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedSubjectSubjectId",
                schema: "dbo",
                table: "User",
                column: "CreatedSubjectSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastModifiedSubjectSubjectId",
                schema: "dbo",
                table: "User",
                column: "LastModifiedSubjectSubjectId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_User_Subject_CreatedSubjectSubjectId",
                schema: "dbo",
                table: "User",
                column: "CreatedSubjectSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Subject_LastModifiedSubjectSubjectId",
                schema: "dbo",
                table: "User",
                column: "LastModifiedSubjectSubjectId",
                principalSchema: "dbo",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_User_Subject_CreatedSubjectSubjectId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Subject_LastModifiedSubjectSubjectId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CreatedSubjectSubjectId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LastModifiedSubjectSubjectId",
                schema: "dbo",
                table: "User");

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
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedSubjectSubjectId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedSubjectSubjectId",
                schema: "dbo",
                table: "User");

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
        }
    }
}
