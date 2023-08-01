using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface CategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        void Save(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
