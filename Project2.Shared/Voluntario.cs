using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project2.Shared
{
    public class Voluntario
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Completo")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string Nombre { get; set; } = string.Empty;

        // Validaciones
        [Display(Name = "Documento de Identidad")]
        [MaxLength(10, ErrorMessage = "Este campo solo permite 10 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo {0} solo permite números.")]
        public string Documento { get; set; } = string.Empty;

        [Display(Name = "Nacionalidad")]
        [MaxLength(50, ErrorMessage = "Este campo solo permite 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string Nacionalidad { get; set; } = string.Empty;

        [Display(Name = "Profesión")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo permite letras y espacios.")]
        public string Profesion { get; set; } = string.Empty;

        [Display(Name = "Idiomas")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z,\s]+$", ErrorMessage = "El campo {0} solo permite letras y comas.")]
        public string Idiomas { get; set; } = string.Empty;

        [Display(Name = "Áreas de Interés")]
        [MaxLength(255, ErrorMessage = "Este campo solo permite 255 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z,\s]+$", ErrorMessage = "El campo {0} solo permite letras y comas.")]
        public string AreasInteres { get; set; } = string.Empty;

        [Display(Name = "Disponibilidad de Tiempo")]
        [MaxLength(100, ErrorMessage = "Este campo solo permite 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo {0} contiene caracteres no válidos.")]
        public string DisponibilidadTiempo { get; set; } = string.Empty;

       
        public virtual ICollection<Participacion> Participaciones { get; set; } = new List<Participacion>();
    }
}
