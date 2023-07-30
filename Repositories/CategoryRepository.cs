using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface CategoryRepository
    {
<<<<<<< HEAD
        List<Category> GetCategorys();
=======
        List<Category> GetCategories();
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
        Category FindCategoryById(int id);
        void SaveCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
