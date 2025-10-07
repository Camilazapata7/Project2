using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared.Models
{
    /// <summary>
    /// Representa el organizador responsable de uno o más proyectos.
    /// </summary>
    public class Organizador
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Nombre del Organizador")]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(20)]
        [Display(Name = "Teléfono de Contacto")]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(400)]
        [Display(Name = "Historial de Impacto Social")]
        public string? HistorialImpactoSocial { get; set; }

        public virtual ICollection<Proyecto> ProyectosLiderados { get; set; } = new List<Proyecto>();
    }
}

