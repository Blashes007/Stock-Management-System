using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string barCode { get; set; }

        [Required(ErrorMessage = "Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Required")]
        public int categoryId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string categoryName { get; set; }
    }
}
