using Microsoft.AspNetCore.Mvc;
using ProductManagement.Entities;
using ProductManagement.Models;

namespace ProductManagement.Interfaces
{
    public interface ICategoryService
    {
        public CategoryModel CreateCategory(CategoryModel category);
        public CategoryModel GetCategory(int Id);
        public List<CategoryModel> GetAllCategories();
        public CategoryModel EditCategory(int Id, CategoryModel category);
        public bool DeleteCategory(int Id);
    }
}
