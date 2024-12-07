using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ReestructurandoProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadMiembro");

            migrationBuilder.CreateTable(
                name: "MiembroActividades",
                columns: table => new
                {
                    MiembroId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiembroActividades", x => new { x.MiembroId, x.ActividadId });
                    table.ForeignKey(
                        name: "FK_MiembroActividades_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiembroActividades_Miembros_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiembroActividades_ActividadId",
                table: "MiembroActividades",
                column: "ActividadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiembroActividades");

            migrationBuilder.CreateTable(
                name: "ActividadMiembro",
                columns: table => new
                {
                    ActividadesId = table.Column<int>(type: "int", nullable: false),
                    MiembrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadMiembro", x => new { x.ActividadesId, x.MiembrosId });
                    table.ForeignKey(
                        name: "FK_ActividadMiembro_Actividades_ActividadesId",
                        column: x => x.ActividadesId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadMiembro_Miembros_MiembrosId",
                        column: x => x.MiembrosId,
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadMiembro_MiembrosId",
                table: "ActividadMiembro",
                column: "MiembrosId");
        }
    }
}
