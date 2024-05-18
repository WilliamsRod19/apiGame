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

        [Required]
        public string GameName { get; set; }

        [Required]
        public string GameDescription { get; set; }

        [Required]
        public DateTime GameReleaseDate { get; set; }

        [Required]
        public decimal GamePrice { get; set; }

        [Required]
        public int GameDeveloperID { get; set; }

        [Required]
        public int GameCategoryID { get; set; }
    }
}
