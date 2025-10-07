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
    /// Representa un voluntario registrado en la plataforma.
    /// </summary>
    public class Voluntario
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(20)]
        [Display(Name = "Documento de Identidad")]
        public string Documento { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Profesión u Oficio")]
        public string Profesion { get; set; } = string.Empty;

        [StringLength(150)]
        [Display(Name = "Idiomas que Domina")]
        public string? Idiomas { get; set; }

        [StringLength(200)]
        [Display(Name = "Áreas de Interés")]
        public string? AreasInteres { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Disponibilidad de Tiempo")]
        public string DisponibilidadTiempo { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string? Email { get; set; }

        public virtual ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}
