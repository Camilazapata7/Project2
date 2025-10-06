using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project2.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreContacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoProyectos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InformacionContacto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HistorialImpactoSocial = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Profesion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Idiomas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AreasInteres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisponibilidadTiempo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UbicacionGeografica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DuracionEstimada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequisitosVoluntarios = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrganizadorId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Organizadores_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntuacion = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    ProyectoId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    VoluntarioId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoluntarioId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    ProyectoId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    HistorialHoras = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    ActividadesRealizadas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participaciones_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participaciones_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TiempoEstimado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ResponsableAsignado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProyectoId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizadores",
                columns: new[] { "Id", "HistorialImpactoSocial", "InformacionContacto", "NombreContacto", "TipoProyectos" },
                values: new object[,]
                {
                    { 1, "Líderes en reforestación en 5 países.", "info@global.org", "ONG Global Ambiental", "Ambiental" },
                    { 2, "Capacitación a más de 1000 jóvenes.", "contacto@techgood.com", "Tech for Good Foundation", "Tecnológico/Educativo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_ProyectoId",
                table: "Evaluaciones",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_VoluntarioId",
                table: "Evaluaciones",
                column: "VoluntarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_ProyectoId",
                table: "Participaciones",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_VoluntarioId",
                table: "Participaciones",
                column: "VoluntarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_OrganizadorId",
                table: "Proyectos",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tareas",
                column: "ProyectoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Participaciones");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Organizadores");
        }
    }
}
