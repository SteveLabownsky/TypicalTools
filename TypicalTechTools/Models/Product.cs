using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TypicalTechTools.Models
{
    public class Product
    {
        [Key]
        public int ProductCode { get; set; }

        [Required (ErrorMessage ="Must enter product name")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9\s\-\.',()]+$", ErrorMessage ="Invalid Characters")] //Regex
        public string ProductName { get; set; }

        [Required (ErrorMessage ="Must enter price")] 
        [Range(0.01, 100000)]
        public decimal ProductPrice { get; set; }

        [Required (ErrorMessage ="Must enter description")]
        [StringLength(500)]
        [RegularExpression(@"^[a-zA-Z0-9\s\-\.',()]+$", ErrorMessage ="Invalid Characters")] //Regex
        public string ProductDescription { get; set; }

        public DateTime Updated {  get; set; } = DateTime.Now;

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
