using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiConsultarVacinas.Migrations
{
    public partial class NovaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosVacinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HitId = table.Column<string>(nullable: true),
                    PacienteId = table.Column<string>(nullable: true),
                    DataSolicitacao = table.Column<string>(nullable: true),
                    DataAplicacao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    SolicitanteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosVacinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosVacinas_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosVacinas_SolicitanteId",
                table: "DadosVacinas",
                column: "SolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosVacinas");

            migrationBuilder.DropTable(
                name: "Solicitantes");
        }
    }
}
