using ProductManagement.Entities;
using ProductManagement.Interfaces;
using ProductManagement.Models;

namespace ProductManagement.Mapping
{
    public class CategoryMapper : IMapper<Category, CategoryModel>
    {
        public CategoryModel MapFromEntityToModel(Category source)
        {
            return new CategoryModel()
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Code = source.Code,
            };
        }

        public Category MapFromModelToEntity(CategoryModel source)
        {
            var entity = new Category();
            MapFromModelToEntity(source, entity);
            return entity;
        }

        public void MapFromModelToEntity(CategoryModel source, Category target)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Code = source.Code;
        }
    }
}
