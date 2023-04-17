using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ptoject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSubjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubId",
                table: "Questions",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubId",
                table: "Questions",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "Questions");
        }
    }
}
