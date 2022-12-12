using ProductManagement.Entities;
using ProductManagement.Interfaces;
using ProductManagement.Models;

namespace ProductManagement.Mapping
{
    public class ProductMapper : IMapper<Product, ProductModel>
    {
        public ProductModel MapFromEntityToModel(Product source)
        {
            return new ProductModel()
            {
                Id = source.Id,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Description = source.Description,
                Price = source.Price
            };
        }

        public Product MapFromModelToEntity(ProductModel source)
        {
            var entity = new Product();
            MapFromModelToEntity(source, entity);
            return entity;
        }

        public void MapFromModelToEntity(ProductModel source, Product target)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.CategoryId = source.CategoryId;
            target.Description = source.Description;
            target.Price = source.Price;
        }
    }
}
