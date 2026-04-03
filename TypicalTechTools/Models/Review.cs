using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypicalTechTools.Models
{
    public class Review
    {

        public int ReviewId { get; set; }
        [Display(Name = "Review")]
        public string ReviewText { get; set; }
        [Display(Name = "Product Code")]
        [ForeignKey("Product")]
        public int ProductCode { get; set; }
        public DateTime ReviewCreated {  get; set; } = DateTime.Now;
        public virtual Product? Product { get; set; }

    }
}
