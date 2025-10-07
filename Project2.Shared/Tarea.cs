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
    /// Representa una tarea asignada dentro de un proyecto.
    /// </summary>
    public class Tarea
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Nombre de la Tarea")]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(300)]
        [Display(Name = "Descripción Detallada")]
        public string Descripcion { get; set; } = string.Empty;

        [Range(1, 1000)]
        [Display(Name = "Horas Estimadas")]
        public int HorasEstimadas { get; set; }

        [ForeignKey("Proyecto")]
        [Display(Name = "Proyecto Asociado")]
        public int ProyectoId { get; set; }

        public virtual Proyecto Proyecto { get; set; } = null!;
    }
}
