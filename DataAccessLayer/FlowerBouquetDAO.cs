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
        private static FlowerBouquetDAO instance;
        private static readonly object instanceLock = new object();
        private FlowerBouquetDAO() { }
        public static FlowerBouquetDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FlowerBouquetDAO();
                    }
                    return instance;
                }
            }
        }
        public static FlowerBouquet Get(int id)
        {
            FlowerBouquet flowerBouquet = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquet = context.FlowerBouquets
                        .Include(x => x.Category)
                        .Include(x => x.Supplier)
                        .SingleOrDefault(flower => flower.FlowerBouquetId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquet;
        }
        public static List<FlowerBouquet> GetAll()
        {
            List<FlowerBouquet> flowerBouquets = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    flowerBouquets = context.FlowerBouquets
                        .Include(x => x.Category)
                        .Include(x => x.Supplier)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return flowerBouquets;
        }
        public static void Save(FlowerBouquet flowerBouquet) 
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
        public static void Update(FlowerBouquet flowerBouquet)
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
        public static void Delete(FlowerBouquet flowerBouquet)
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
    }
}
