using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        private static readonly object locker = new object();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }
        public static List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    customers = context.Customers.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customers;
        }
        public static Customer Get(int id)
        {
            Customer customer = new Customer();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    customer = context.Customers.SingleOrDefault(c => c.CustomerId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customer;
        }
        public static void Save(Customer customer)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Update(Customer customer)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Delete(Customer customer)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Customers.Remove(customer);
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
