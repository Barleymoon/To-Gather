using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Gather.Data;
using To_Gather.Models.CategoryModels;

namespace To_Gather.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            Category category = new Category()
            {
                OwnerId = _userId,
                Title = model.Title,
                Description = model.Description
            };
            _db.Categories.Add(category);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            IEnumerable<CategoryListItem> category = _db.Categories.Select(c => new CategoryListItem
            {
                CategoryId = c.CategoryId,
                Title = c.Title,
                Description = c.Description,
            }).ToList();
            return category;
        }

        public CategoryDetail GetCategoryById(int id)
        {
            Category getCategory = _db.Categories.Single(c => c.CategoryId == id);
            CategoryDetail detailCategory = new CategoryDetail()
            {
                CategoryId = getCategory.CategoryId,
                Title = getCategory.Title,
                Description = getCategory.Description,
                CategoryActivities = getCategory.CategoryActivities.Select(a => new ActivityDisplayItem()
                {
                    Title = a.Title
                }).ToList()
            };
            return detailCategory;
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            Category editCategroy = _db.Categories.Single(c => c.CategoryId == model.CategoryId);
            editCategroy.CategoryId = model.CategoryId;
            editCategroy.Title = model.Title;
            editCategroy.Description = model.Description;

            return _db.SaveChanges() > 0;
        }

        public bool DeleteCategories(int id)
        {
            Category deleteCategory = _db.Categories.Single(c => c.CategoryId == id);
            _db.Categories.Remove(deleteCategory);
            return _db.SaveChanges() == 1;
        }
    }
}
