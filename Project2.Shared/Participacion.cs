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
    /// Representa la participación de un voluntario en un proyecto.
    /// </summary>
    public class Participacion
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Voluntario")]
        public int VoluntarioId { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }

        [Range(0, 2000)]
        [Display(Name = "Horas Realizadas")]
        public int HorasRealizadas { get; set; }

        [StringLength(300)]
        [Display(Name = "Actividades Desarrolladas")]
        public string? Actividades { get; set; }

        public virtual Voluntario Voluntario { get; set; } = null!;
        public virtual Proyecto Proyecto { get; set; } = null!;
    }
}
