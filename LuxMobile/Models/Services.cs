using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LuxMobile.Models
{
    public class Services
    {
        [Key]
        public int ServiceNo { get; set; }

        [Display(Name = "Service")]
        [Required(ErrorMessage = "Required.")]
        public string ServiceName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required.")]
        public decimal Price { get; set; }
    }
}
