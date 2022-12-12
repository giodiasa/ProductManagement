using ProductManagement.Models;

namespace ProductManagement.Interfaces
{
    public interface IProductService
    {
        public ProductModel CreateProduct(ProductModel product);
        public ProductModel GetProduct(int Id);
        public List<ProductModel> GetAllProducts();
        public ProductModel EditProduct(int Id, ProductModel product);
        public bool DeleteProduct(int Id);
    }
}
