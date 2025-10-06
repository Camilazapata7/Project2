using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared
{
    public class Participacion
    {
        public int Id { get; set; }

        // Foreign Key (FK)
        [Display(Name = "ID Voluntario")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public int VoluntarioId { get; set; }

        // Foreign Key (FK)
        [Display(Name = "ID Proyecto")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public int ProyectoId { get; set; }

        [Display(Name = "Horas Registradas")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo {0} debe ser un número positivo (con hasta 2 decimales).")]
        public decimal HistorialHoras { get; set; }

        [Display(Name = "Actividades Realizadas")]
        [MaxLength(500, ErrorMessage = "Este campo solo permite 500 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,]+$", ErrorMessage = "El campo {0} contiene caracteres no válidos.")]
        public string ActividadesRealizadas { get; set; } = string.Empty;

       
        public virtual Voluntario Voluntario { get; set; } = null!;
        public virtual Proyecto Proyecto { get; set; } = null!;
    }
}
