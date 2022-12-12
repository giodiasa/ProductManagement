using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using ProductManagement.Interfaces;
using ProductManagement.Mapping;
using ProductManagement.Models;

namespace ProductManagement.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ProductManagementContext _context;
        public readonly IMapper<Category, CategoryModel> _categoryMapper;
        public CategoryService(ProductManagementContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }

        public CategoryModel CreateCategory(CategoryModel category)
        {
           var categoryAlreadyExists = _context.Categories.Any(c => c.Name == category.Name);
           if (categoryAlreadyExists)
            {
                throw new Microsoft.EntityFrameworkCore.DbUpdateException($"Category with name '{category.Name}' already exists");
            }
           var categoryEntity = _categoryMapper.MapFromModelToEntity(category);

            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();
           category = _categoryMapper.MapFromEntityToModel(categoryEntity);
           return category;
        }
        public CategoryModel GetCategory (int Id)
        {
            var entity = _context.Categories.Find(Id);
            if (entity == null)
            {
                return new CategoryModel() { };
            }
            return _categoryMapper.MapFromEntityToModel(entity);
        }
        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> categories = new();
            foreach (var item in _context.Categories)
            {
                categories.Add(_categoryMapper.MapFromEntityToModel(item));
            }
            return categories;
        }

        public CategoryModel EditCategory(int Id, CategoryModel category)
        {
            if(!_context.Categories.Any(x => x.Id == Id))
            {
                return new CategoryModel() { };
            }
            _context.Entry(_categoryMapper.MapFromModelToEntity(category)).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }

        public bool DeleteCategory(int Id)
        {
            var cat = _context.Categories.Find(Id);
            if (cat == null)
            {
                return false;
            }
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return true;
        }


    }
}
