using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    categories = context.Categories.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categories;
        }
        public static Category FindCategoryById(int id)
        {
            Category category = new Category();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    category = context.Categories.SingleOrDefault(c => c.CategoryId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return category;
        }
        public static void SaveCategory(Category category)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateCategory(Category category)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Categories.Update(category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteCategory(Category category)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
