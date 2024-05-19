using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la categoría debe tener entre 3 y 50 caracteres.")]
        [Display(Name = "Nombre de la categoria")]
        public string CategoryName { get; set; }
    }
}
