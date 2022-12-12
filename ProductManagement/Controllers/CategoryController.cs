using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using ProductManagement.Interfaces;
using ProductManagement.Models;
using System.Data.Entity;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("CreateCategory")]
        public CategoryModel CreateCategory(CategoryModel category) => _categoryService.CreateCategory(category);
        

        [HttpGet("GetCategory/{Id}")]
        public CategoryModel GetCategory (int Id) => _categoryService.GetCategory(Id);
        

        [HttpGet("GetAllCategories")]
        public List<CategoryModel> GetAllCategories() => _categoryService.GetAllCategories();
        

        [HttpPut("EditCategory/{Id}")]
        public CategoryModel EditCategory(int Id, CategoryModel category) => _categoryService.EditCategory(Id, category);
        

        [HttpDelete("DeleteCategory/{Id}")]
        public bool DeleteCategory(int Id) => _categoryService.DeleteCategory(Id);
        
    }
}
