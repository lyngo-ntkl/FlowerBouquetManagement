using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface CategoryRepository
    {
        List<Category> GetCategories();
        Category FindCategoryById(int id);
        void SaveCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
