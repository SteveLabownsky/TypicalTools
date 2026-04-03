using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TypicalTechTools.Models
{
    public class Product
    {
        public int ProductCode { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [Required, Range(0.01, 100000)]
        public decimal ProductPrice { get; set; }

        [Required, StringLength(500)]
        public string ProductDescription { get; set; }

        public DateTime Updated {  get; set; } = DateTime.Now;
    }
}
