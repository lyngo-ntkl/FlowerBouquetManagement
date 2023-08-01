using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private static readonly object instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        public static List<Category> GetAll()
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
        public static Category Get(int id)
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
        public static void Save(Category category)
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
        public static void Update(Category category)
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
        public static void Delete(Category category)
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
