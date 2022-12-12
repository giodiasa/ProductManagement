using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Entities
{
    public class Category
    { 
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEnumerable <Product> Products { get; set; } = null!;
    }
}
