using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared
{
    public class Organizador
    {
        // El ID principal no requiere validación explícita más allá de [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre de Contacto")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string NombreContacto { get; set; } = string.Empty;

        [Display(Name = "Tipo de Proyectos")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string TipoProyectos { get; set; } = string.Empty;

        [Display(Name = "Información de Contacto")]
        [MaxLength(255, ErrorMessage = "Este campo solo permite 255 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El campo {0} debe ser una dirección de correo válida.")]
        public string InformacionContacto { get; set; } = string.Empty;

        [Display(Name = "Historial de Impacto Social")]
        [MaxLength(500, ErrorMessage = "Este campo solo permite 500 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,]+$", ErrorMessage = "El campo {0} contiene caracteres no válidos.")]
        public string HistorialImpactoSocial { get; set; } = string.Empty;

        // Propiedad de Navegación
        public virtual ICollection<Proyecto> ProyectosLiderados { get; set; } = new List<Proyecto>();
    }
}
