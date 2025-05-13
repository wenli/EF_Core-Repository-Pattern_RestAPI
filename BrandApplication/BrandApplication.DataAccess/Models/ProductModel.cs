using System.ComponentModel.DataAnnotations;

namespace BrandApplication.DataAccess.Models
{
    public class ProductModel
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelName { get; set; } = string.Empty; // Initialize with default value

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = default!; // Use null-forgiving operator for EF Core populated property
    }
}
