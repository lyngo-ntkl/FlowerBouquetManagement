using BusinessObjects.Models;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
=======
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
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
<<<<<<< HEAD
=======
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
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
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
<<<<<<< HEAD
=======
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
        //public static async Task<List<FlowerBouquet>> GetFlowerBouquetsWithCategoryAndSupplier()
        //{
        //    List<FlowerBouquet> flowerBouquets = new List<FlowerBouquet>();
        //    try
        //    {
        //        using (var context = new FUFlowerBouquetManagementContext())
        //        {
        //            flowerBouquets = await context.FlowerBouquets
        //                .Include(flowerBouquets => flowerBouquets.Category)
        //                .Include(flowerBouquets => flowerBouquets.Supplier)
        //                .ToListAsync();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return flowerBouquets;
        //}
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
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
<<<<<<< HEAD
                    flowerBouquet = context.FlowerBouquets.OrderByDescending(f => f.FlowerBouquetId).Max();
=======
                    flowerBouquet = context.FlowerBouquets.OrderByDescending(f => f.FlowerBouquetId).FirstOrDefault();
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
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
