using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Interfaces;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("CreateProduct")]
        public ProductModel CreateProduct(ProductModel product) => _productService.CreateProduct(product);

        [HttpDelete("DeleteProduct/{Id}")]
        public bool DeleteProduct(int Id) => _productService.DeleteProduct(Id);

        [HttpPut("EditProduct/{Id}")]
        public ProductModel EditProduct(int Id, ProductModel product) => _productService.EditProduct(Id, product);

        [HttpGet("GetAllProducts")]
        public List<ProductModel> GetAllProducts() => _productService.GetAllProducts();

        [HttpGet("GetProduct/{Id}")]
        public ProductModel GetProduct(int Id) => _productService.GetProduct(Id);

    }
}
