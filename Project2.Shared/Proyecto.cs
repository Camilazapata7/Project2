using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Proyecto")]
        [MaxLength(150, ErrorMessage = "Este campo solo permite 150 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo {0} solo permite letras, números y espacios.")]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Categoría")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string Categoria { get; set; } = string.Empty;

        [Display(Name = "Ubicación Geográfica")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo {0} solo permite letras, números y espacios.")]
        public string UbicacionGeografica { get; set; } = string.Empty;

        [Display(Name = "Duración Estimada")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo {0} solo permite letras, números y espacios.")]
        public string DuracionEstimada { get; set; } = string.Empty;

        [Display(Name = "Requisitos del Voluntario")]
        [MaxLength(255, ErrorMessage = "Este campo solo permite 255 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,]+$", ErrorMessage = "El campo {0} contiene caracteres no válidos.")]
        public string RequisitosVoluntarios { get; set; } = string.Empty;

        // Foreign Key (FK) para Organizador
        [Display(Name = "ID Organizador")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public int OrganizadorId { get; set; }
        public virtual Organizador Organizador { get; set; } = null!;

        
        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        public virtual ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}
