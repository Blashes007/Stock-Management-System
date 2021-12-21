using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class Supplier
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string name{ get; set; }

        [Required(ErrorMessage = "Required")]

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Required(ErrorMessage = "Required")]
       
        public string phone { get; set; }
    }
}
