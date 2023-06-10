using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);

        public Category FindCategoryById(int id) => CategoryDAO.FindCategoryById(id);

        public List<Category> GetCategorys() => CategoryDAO.GetCategories();

        public void SaveCategory(Category category) => CategoryDAO.SaveCategory(category);

        public void UpdateCategory(Category category) => CategoryDAO.UpdateCategory(category);
    }
}
