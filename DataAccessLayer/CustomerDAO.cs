using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
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
        public static Customer FindCustomerById(int id)
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
        public static Customer FindCustomerByEmailAndPassword(string email, string password)
        {
            Customer customer = new Customer();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    customer = context.Customers.SingleOrDefault(c => c.Email == email && c.Password == password);
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customer;
        }
        public static void SaveCustomer(Customer customer)
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
        public static void UpdateCustomer(Customer customer)
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
        public static void DeleteCustomer(Customer customer)
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

        public static List<Customer> FindCustomersContainName(string name)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    customers = context.Customers.Where(customer => customer.CustomerName.Contains(name)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customers;
        }
        public static Customer GetCustomerWithTheLargestId()
        {
            Customer customer = new Customer();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    customer = context.Customers.OrderByDescending(c => c.CustomerId).Max();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customer;
        }
    }
}
