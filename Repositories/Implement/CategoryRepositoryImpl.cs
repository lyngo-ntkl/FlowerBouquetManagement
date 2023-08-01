using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        public void Delete(Category category) => CategoryDAO.Delete(category);

        public Category Get(int id) => CategoryDAO.Get(id);

        public List<Category> GetAll() => CategoryDAO.GetAll();

        public void Save(Category category) => CategoryDAO.Save(category);

        public void Update(Category category) => CategoryDAO.Update(category);
    }
}
