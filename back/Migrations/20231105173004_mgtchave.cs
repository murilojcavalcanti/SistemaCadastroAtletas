using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    public partial class mgtchave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtletaCampeonato",
                columns: table => new
                {
                    AtletaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaCampeonato", x => new { x.AtletaId, x.CampeonatoId });
                    table.ForeignKey(
                        name: "FK_AtletaCampeonato_AspNetUsers_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaCampeonato_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faixa = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chaves_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChavesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lutas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lutas_Chaves_ChavesId",
                        column: x => x.ChavesId,
                        principalTable: "Chaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtletasLutas",
                columns: table => new
                {
                    AtletasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LutasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletasLutas", x => new { x.AtletasId, x.LutasId });
                    table.ForeignKey(
                        name: "FK_AtletasLutas_AspNetUsers_AtletasId",
                        column: x => x.AtletasId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletasLutas_Lutas_LutasId",
                        column: x => x.LutasId,
                        principalTable: "Lutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaCampeonato_CampeonatoId",
                table: "AtletaCampeonato",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletasLutas_LutasId",
                table: "AtletasLutas",
                column: "LutasId");

            migrationBuilder.CreateIndex(
                name: "IX_Chaves_CampeonatoId",
                table: "Chaves",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lutas_ChavesId",
                table: "Lutas",
                column: "ChavesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaCampeonato");

            migrationBuilder.DropTable(
                name: "AtletasLutas");

            migrationBuilder.DropTable(
                name: "Lutas");

            migrationBuilder.DropTable(
                name: "Chaves");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers");
        }
    }
}
