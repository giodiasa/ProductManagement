using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using ProductManagement.Interfaces;
using ProductManagement.Mapping;
using ProductManagement.Models;

namespace ProductManagement.Services
{

    public class ProductService : IProductService 
    {
        public readonly ProductManagementContext _context;
        public readonly IMapper<Product, ProductModel> _productMapper;

        public ProductService(ProductManagementContext context)
        {
            _context = context;
            _productMapper = new ProductMapper();
        }

        public ProductModel CreateProduct(ProductModel product)
        {
            var productAlreadyExists = _context.Products.Any(c => c.Name == product.Name);
            if (productAlreadyExists)
            {
                throw new DbUpdateException($"Product with name '{product.Name}' already exists");
            }
            var productEntity = _productMapper.MapFromModelToEntity(product);
            _context.Products.Add(productEntity);
            _context.SaveChanges();
            product = _productMapper.MapFromEntityToModel(productEntity);
            return product;
        }

        public bool DeleteProduct(int Id)
        {
            var product = _context.Products.Find(Id);
            if(product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public ProductModel EditProduct(int Id, ProductModel product)
        {
            if (!_context.Products.Any(x => x.Id == Id))
            {
                return new ProductModel() { };
            }
            _context.Entry(_productMapper.MapFromModelToEntity(product)).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new();
            foreach (var item in _context.Products)
            {
                products.Add(_productMapper.MapFromEntityToModel(item));
            }
            return products;
        }

        public ProductModel GetProduct(int Id)
        {
            var entity = _context.Products.Find(Id);
            if (entity == null)
            {
                return new ProductModel() { };
            }
            return _productMapper.MapFromEntityToModel(entity);
        }
    }
}
