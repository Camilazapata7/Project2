using Microsoft.EntityFrameworkCore;
using Project2.Shared; // Importante para usar las clases de tu proyecto Shared

namespace Project2.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets: Aquí defines las tablas de tu base de datos
        public DbSet<Organizador> Organizadores { get; set; } = null!;
        public DbSet<Proyecto> Proyectos { get; set; } = null!;
        public DbSet<Voluntario> Voluntarios { get; set; } = null!;
        public DbSet<Participacion> Participaciones { get; set; } = null!;
        public DbSet<Tarea> Tareas { get; set; } = null!;
        public DbSet<Evaluacion> Evaluaciones { get; set; } = null!;

        // Configuración de Modelado y Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🚨 1. CORRECCIÓN PARA ADVERTENCIA DECIMAL (HistorialHoras) 
            // Esto le dice a SQL Server que use un formato DECIMAL(18, 2)
            modelBuilder.Entity<Participacion>()
                .Property(p => p.HistorialHoras)
                .HasColumnType("decimal(18, 2)");


            // 2. SeedDb (Datos iniciales) - Ejemplo de Organizador
            // Estos datos se insertarán cuando ejecutes Update-Database.
            modelBuilder.Entity<Organizador>().HasData(
                new Organizador
                {
                    Id = 1,
                    NombreContacto = "ONG Global Ambiental",
                    TipoProyectos = "Ambiental",
                    InformacionContacto = "info@global.org",
                    HistorialImpactoSocial = "Líderes en reforestación en 5 países."
                },
                new Organizador
                {
                    Id = 2,
                    NombreContacto = "Tech for Good Foundation",
                    TipoProyectos = "Tecnológico/Educativo",
                    InformacionContacto = "contacto@techgood.com",
                    HistorialImpactoSocial = "Capacitación a más de 1000 jóvenes."
                }
            );

            // 🚨 IMPORTANTE: Si deseas añadir datos de prueba (Seed Data) para tus otras 5 entidades, 
            // debes hacerlo aquí, siguiendo el mismo formato de modelBuilder.Entity<...>().HasData(...).

            base.OnModelCreating(modelBuilder);
        }
    }
}