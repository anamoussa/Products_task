using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Front.viewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Product Qauntity")]
        public int Qauntity { get; set; }

    }
}
