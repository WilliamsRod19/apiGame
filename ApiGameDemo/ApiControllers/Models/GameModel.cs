using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
    public class GameModel
    {
        public int GameID { get; set; }

        [Required(ErrorMessage = "El nombre del juego es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del juego debe tener entre 3 y 100 caracteres.")]
        [Display(Name = "Nombre del Juego")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "La descripción del juego es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción del juego no debe exceder los 500 caracteres.")]
        [Display(Name = "Descripcion del Juego")]
        public string GameDescription { get; set; }

        [Required(ErrorMessage = "La fecha de lanzamiento del juego es obligatoria.")]
        [Display(Name = "Fecha de lanzamiento del juego")]
        public DateTime GameReleaseDate { get; set; }

        [Required(ErrorMessage = "El precio del juego es obligatorio.")]
        [Range(0.00, 999.99, ErrorMessage = "El precio del juego debe estar entre $0.00 y $999.99.")]
        [Display(Name = "Precio del Juego")]
        public decimal GamePrice { get; set; }

        [Required(ErrorMessage = "El ID del desarrollador es obligatorio.")]
        [Display(Name = "Desarrollador del juego")]
        public int GameDeveloperID { get; set; }

        [Required(ErrorMessage = "El ID de la categoría es obligatorio.")]
        [Display(Name = "Categoria del Juego")]
        public int GameCategoryID { get; set; }


        public DeveloperModel? Developer { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
