using System.ComponentModel.DataAnnotations;

namespace BrandApplication.DataAccess.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty; // Initialize with default value

        public ICollection<ProductModel> Models { get; set; } = new List<ProductModel>(); // Initialize with default value
    }
}