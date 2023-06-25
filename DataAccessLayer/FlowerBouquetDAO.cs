using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class FlowerBouquetDAO
    {
        public static FlowerBouquet FindFlowerBouquetsById(int id)
        {
            FlowerBouquet flowerBouquet = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquet = context.FlowerBouquets.SingleOrDefault(flower => flower.FlowerBouquetId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquet;
        }
        public static FlowerBouquet FindFlowerBouquetsByIdWithCategoryAndSupplierAsync(int id)
        {
            FlowerBouquet flowerBouquet = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquet = context.FlowerBouquets
                        .Include(f => f.Supplier)
                        .Include(f => f.Category)
                        .SingleOrDefault(flower => flower.FlowerBouquetId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquet;
        }
        public static List<FlowerBouquet> GetFlowerBouquets()
        {
            List<FlowerBouquet> flowerBouquets = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquets = context.FlowerBouquets.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquets;
        }
        public static List<FlowerBouquet> GetFlowerBouquetsWithCategoryAndSupplier()
        {
            List<FlowerBouquet> flowerBouquets = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquets = context.FlowerBouquets
                        .Include(flowerBouquets => flowerBouquets.Category)
                        .Include(flowerBouquets => flowerBouquets.Supplier)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquets;
        }
        public static void SaveFlowerBouquet(FlowerBouquet flowerBouquet) 
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.FlowerBouquets.Add(flowerBouquet);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateFlowerBouquet(FlowerBouquet flowerBouquet)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.FlowerBouquets.Update(flowerBouquet);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteFlowerBouquet(FlowerBouquet flowerBouquet)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.FlowerBouquets.Remove(flowerBouquet);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static List<FlowerBouquet> FindFlowerBouquetContainName(string name)
        {
            List<FlowerBouquet> flowerBouquets = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquets = context.FlowerBouquets.Where(flowerBouquet => flowerBouquet.FlowerBouquetName.Contains(name)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquets;
        }
        public static FlowerBouquet GetFlowerBouquetWithTheLargestId()
        {
            FlowerBouquet flowerBouquet = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquet = context.FlowerBouquets.OrderByDescending(f => f.FlowerBouquetId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquet;
        }
    }
}
