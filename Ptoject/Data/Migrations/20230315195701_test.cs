using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ptoject.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.CreateTable(
                name: "AnswerUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeeQuestion = table.Column<double>(type: "float", nullable: false),
                    DegreeeStudent = table.Column<double>(type: "float", nullable: false),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerUser_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerUser_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerUser_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionUser_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionUser_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          

           

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUser_AnswerID",
                table: "AnswerUser",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUser_ApplicationDbUserId",
                table: "AnswerUser",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUser_QuestionID",
                table: "AnswerUser",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionUser_ApplicationDbUserId",
                table: "QuestionUser",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionUser_QuestionsId",
                table: "QuestionUser",
                column: "QuestionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerUser");

            migrationBuilder.DropTable(
                name: "QuestionUser");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "42127fab-3088-4d0a-95e8-722c328429c8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "f607027d-079c-4fce-be92-5280a1d25de0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exames_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    AnswerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeeQuestion = table.Column<double>(type: "float", nullable: false),
                    DegreeeStudent = table.Column<double>(type: "float", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ApplicationDbUserId",
                table: "Exames",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_QuestionsId",
                table: "Exames",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_AnswerID",
                table: "StudentAnswers",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionID",
                table: "StudentAnswers",
                column: "QuestionID");
        }
    }
}
