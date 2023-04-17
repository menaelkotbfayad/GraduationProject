using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ptoject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColUserIdinExame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Questions_QuestionId",
                table: "Exames");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Exames",
                newName: "QuestionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Exames_QuestionId",
                table: "Exames",
                newName: "IX_Exames_QuestionsId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationDbUserId",
                table: "Exames",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ApplicationDbUserId",
                table: "Exames",
                column: "ApplicationDbUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_AspNetUsers_ApplicationDbUserId",
                table: "Exames",
                column: "ApplicationDbUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Questions_QuestionsId",
                table: "Exames",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_AspNetUsers_ApplicationDbUserId",
                table: "Exames");

            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Questions_QuestionsId",
                table: "Exames");

            migrationBuilder.DropIndex(
                name: "IX_Exames_ApplicationDbUserId",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "ApplicationDbUserId",
                table: "Exames");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "Exames",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Exames_QuestionsId",
                table: "Exames",
                newName: "IX_Exames_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Questions_QuestionId",
                table: "Exames",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
