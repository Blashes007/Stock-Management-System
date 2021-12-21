using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class Sales
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int billNo { get; set; }

        [Required(ErrorMessage = "Required")]
        public int productId { get; set; }

        [Required(ErrorMessage = "Required")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Required")]
        public double unitPrice { get; set; }

        [Required(ErrorMessage = "Required")]
        public double total { get; set; }

        [Required(ErrorMessage = "Required")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Required")]
        public int SN { get; set; }

        [Required(ErrorMessage = "Required")]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string customerName { get; set; }


    }
}
