using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared
{
    public class Tarea
    {
        public int Id { get; set; }

        [Display(Name = "Descripción de la Tarea")]
        [MaxLength(255, ErrorMessage = "Este campo solo permite 255 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,]+$", ErrorMessage = "El campo {0} contiene caracteres no válidos.")]
        public string Descripcion { get; set; } = string.Empty;

        [Display(Name = "Tiempo Estimado")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo {0} solo permite letras, números y espacios.")]
        public string TiempoEstimado { get; set; } = string.Empty;

        [Display(Name = "Lugar")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo {0} solo permite letras, números y espacios.")]
        public string Lugar { get; set; } = string.Empty;

        [Display(Name = "Responsable Asignado")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string ResponsableAsignado { get; set; } = string.Empty;

        // Foreign Key (FK)
        [Display(Name = "ID Proyecto")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; } = null!;
    }
}
