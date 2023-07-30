using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);

        public Category FindCategoryById(int id) => CategoryDAO.FindCategoryById(id);

<<<<<<< HEAD
        public List<Category> GetCategorys() => CategoryDAO.GetCategories();
=======
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

        public void SaveCategory(Category category) => CategoryDAO.SaveCategory(category);

        public void UpdateCategory(Category category) => CategoryDAO.UpdateCategory(category);
    }
}
