using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared
{
    public class Evaluacion
    {
        public int Id { get; set; }

        [Display(Name = "Puntuación (1-5)")]
        [MaxLength(1, ErrorMessage = "Este campo solo permite 1 caracter")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[1-5]$", ErrorMessage = "La {0} debe ser un dígito entre 1 y 5.")]
        public int Puntuacion { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(500, ErrorMessage = "Este campo solo permite 500 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,]+$", ErrorMessage = "El campo {0} contiene caracteres no válidos.")]
        public string Comentario { get; set; } = string.Empty;

        [Display(Name = "Fecha de Evaluación")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9\-/\s\:]+$", ErrorMessage = "El campo {0} contiene un formato de fecha no válido.")]
        public DateTime FechaEvaluacion { get; set; } = DateTime.UtcNow;

        // Fkoreign Key (FK) a Proyecto
        [Display(Name = "ID Proyecto")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; } = null!;

        // Foreign Key (FK) a Voluntario (Opcional)
        [Display(Name = "ID Voluntario Evaluador")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public int? VoluntarioId { get; set; }
        public virtual Voluntario? Voluntario { get; set; }
    }
}
