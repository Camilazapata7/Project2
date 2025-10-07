using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Shared.Models
{
    /// <summary>
    /// Representa un proyecto de voluntariado liderado por un organizador.
    /// </summary>
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Nombre del Proyecto")]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(200)]
        [Display(Name = "Descripción del Proyecto")]
        public string Descripcion { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; } = string.Empty;

        [Required, Range(1, 60)]
        [Display(Name = "Duración Estimada (meses)")]
        public int DuracionEstimadaMeses { get; set; }

        [Required, StringLength(300)]
        [Display(Name = "Requisitos del Voluntario")]
        public string RequisitosDelVoluntario { get; set; } = string.Empty;

        [Required, StringLength(200)]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; } = string.Empty;

        [ForeignKey("Organizador")]
        [Display(Name = "ID del Organizador")]
        public int OrganizadorId { get; set; }

        /// <summary>Organizador líder del proyecto.</summary>
        public virtual Organizador Organizador { get; set; } = null!;

        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        public virtual ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}
