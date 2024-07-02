using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSchool_API.Migrations
{
    /// <inheritdoc />
    public partial class alteracaonometabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Professor_ProfessorId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.RenameTable(
                name: "Professor",
                newName: "Professores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Professores_ProfessorId",
                table: "Alunos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Professores_ProfessorId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.RenameTable(
                name: "Professores",
                newName: "Professor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Professor_ProfessorId",
                table: "Alunos",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
