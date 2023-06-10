using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer
{
    public class SupplierDAO
    {
        public static List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    suppliers = context.Suppliers.ToList();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return suppliers;
        }

        public static Supplier FindSupplierById(int supplierId) { 
            Supplier supplier = new Supplier();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    supplier = context.Suppliers.SingleOrDefault(s => s.SupplierId == supplierId);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return supplier;
        }

        public static void SaveSupplier(Supplier supplier)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();
                }
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateSupplier(Supplier supplier)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Entry<Supplier>(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteSupplier(Supplier supplier)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    Supplier s1 = context.Suppliers.SingleOrDefault(s => s.SupplierId.Equals(supplier.SupplierId));
                    context.Suppliers.Remove(s1);
                    context.SaveChanges();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
