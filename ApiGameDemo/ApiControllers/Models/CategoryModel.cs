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

        [Required]
        public string CategoryName { get; set; }
    }
}
