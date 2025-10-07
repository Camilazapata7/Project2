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
    /// Representa una evaluación realizada sobre un proyecto o voluntario.
    /// </summary>
    public class Evaluacion
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Comentarios de la Evaluación")]
        public string Comentarios { get; set; } = string.Empty;

        [Required, Range(1, 10)]
        [Display(Name = "Calificación (1 a 10)")]
        public int Calificacion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Evaluación")]
        public DateTime FechaEvaluacion { get; set; } = DateTime.UtcNow;

        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }

        [ForeignKey("Voluntario")]
        public int VoluntarioId { get; set; }

        public virtual Proyecto Proyecto { get; set; } = null!;
        public virtual Voluntario Voluntario { get; set; } = null!;
    }
}
