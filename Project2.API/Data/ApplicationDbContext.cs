using Microsoft.EntityFrameworkCore;
using Project2.Shared; 

namespace Project2.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Organizador> Organizadores { get; set; } = null!;
        public DbSet<Proyecto> Proyectos { get; set; } = null!;
        public DbSet<Voluntario> Voluntarios { get; set; } = null!;
        public DbSet<Participacion> Participaciones { get; set; } = null!;
        public DbSet<Tarea> Tareas { get; set; } = null!;
        public DbSet<Evaluacion> Evaluaciones { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Configuraciones adicionales
            modelBuilder.Entity<Participacion>()
                .Property(p => p.HistorialHoras)
                .HasColumnType("decimal(18, 2)");


            // 2. SeedDb (Datos iniciales)
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



            base.OnModelCreating(modelBuilder);
        }
    }
}