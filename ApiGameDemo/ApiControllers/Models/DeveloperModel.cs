using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
    public class DeveloperModel
    {

        public int DeveloperID { get; set; }

        [Required(ErrorMessage = "El nombre del desarrollador es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del desarrollador debe tener entre 3 y 50 caracteres.")]
        [Display(Name = "Nombre del desarrollador")]
        public string DeveloperName { get; set; }

        [Required(ErrorMessage = "El país del desarrollador es obligatorio.")]
        [StringLength(50, ErrorMessage = "El país del desarrollador no debe exceder los 50 caracteres.")]
        [Display(Name = "Pais del desarrollador")]
        public string DeveloperCountry { get; set; }
    }
}
