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

        [Required]
        public string DeveloperName { get; set; }

        [Required]
        public string DeveloperCountry { get; set; }
    }
}
