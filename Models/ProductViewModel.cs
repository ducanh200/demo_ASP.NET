using System.ComponentModel.DataAnnotations;

namespace T2207A_MVC.Models
{
    public class ProductViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int category_id { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int brand_id { get; set; }
    }
}
